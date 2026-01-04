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

public sealed class UserToUserChatMessageSendNotificationOutboxPendingWorker(
    IUserToUserChatNotificationsHubService userToUserChatNotificationsHubService,
    IOutboxBatchStrategy<UserToUserChatMessageSendNotificationOutbox> outboxBatchStrategy,
    ISelectPendingStrategyBuilder selectPendingStrategyBuilder,
    ILogger<UserToUserChatMessageSendNotificationOutboxPendingWorker> logger
) : BaseBackgroundWorker<UserToUserChatMessageSendNotificationOutboxPendingWorker>(
    logger
)
{
    private const int CycleDelayInSeconds = 5;
    private const int BatchCount = 5;

    protected override async Task DoWorkAsync(
        CancellationToken cancellationToken
    )
    {
        var selectPendingStrategyBuilderArgs =
            new SelectPendingStrategyBuilderArgs(
                BatchCount
            );

        var outboxBatchStrategyArgs =
            selectPendingStrategyBuilder
                .Build<UserToUserChatMessageSendNotificationOutbox>(
                    selectPendingStrategyBuilderArgs
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