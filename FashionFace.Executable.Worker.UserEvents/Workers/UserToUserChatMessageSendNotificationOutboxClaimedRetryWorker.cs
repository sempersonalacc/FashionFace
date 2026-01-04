using System;
using System.Threading;
using System.Threading.Tasks;

using FashionFace.Dependencies.SignalR.Interfaces;
using FashionFace.Dependencies.SignalR.Models;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Repositories.Strategy.Builders.Args;
using FashionFace.Repositories.Strategy.Builders.Interfaces;
using FashionFace.Repositories.Strategy.Interfaces;

using Microsoft.Extensions.Logging;

namespace FashionFace.Executable.Worker.UserEvents.Workers;

public sealed class UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker(
    IUserToUserChatNotificationsHubService userToUserChatNotificationsHubService,
    IOutboxBatchStrategy<UserToUserChatMessageSendNotificationOutbox> outboxBatchStrategy,
    ISelectClaimedRetryStrategyBuilder selectClaimedRetryStrategyBuilder,
    ILogger<UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker> logger
) : BaseBackgroundWorker<UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker>(
    logger
)
{
    private const int CycleDelayInSeconds = 5;
    private const int RetryDelayMinutes = 5;
    private const int BatchCount = 5;

    protected override async Task DoWorkAsync(
        CancellationToken cancellationToken
    )
    {
        var selectClaimedRetryStrategyBuilderArgs =
            new SelectClaimedRetryStrategyBuilderArgs(
                BatchCount,
                RetryDelayMinutes
            );

        var outboxBatchStrategyArgs =
            selectClaimedRetryStrategyBuilder
                .Build<UserToUserChatMessageSendNotificationOutbox>(
                    selectClaimedRetryStrategyBuilderArgs
                );

        var userToUserChatMessageOutboxList =
            await
                outboxBatchStrategy
                    .ClaimBatchAsync(
                        outboxBatchStrategyArgs
                    );

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        foreach (var userToUserChatMessageOutbox in userToUserChatMessageOutboxList)
        {
            var messageReceivedMessage =
                new MessageReceivedMessage(
                    userToUserChatMessageOutbox.ChatId,
                    userToUserChatMessageOutbox.InitiatorUserId,
                    userToUserChatMessageOutbox.MessageId,
                    userToUserChatMessageOutbox.MessageValue,
                    userToUserChatMessageOutbox.MessagePositionIndex,
                    userToUserChatMessageOutbox.MessageCreatedAt
                );

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await
                userToUserChatNotificationsHubService
                    .NotifyMessageReceived(
                        userToUserChatMessageOutbox.TargetUserId,
                        messageReceivedMessage
                    );

            await
                outboxBatchStrategy
                    .MakeDoneAsync(
                        userToUserChatMessageOutbox
                    );
        }
    }

    protected override TimeSpan GetDelay() =>
        TimeSpan
            .FromSeconds(
                CycleDelayInSeconds
            );
}