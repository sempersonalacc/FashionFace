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
    IGenericSelectClaimedRetryStrategyBuilder genericSelectClaimedRetryStrategyBuilder,
    ILogger<UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker> logger
) : BaseBackgroundWorker<UserToUserChatMessageSendNotificationOutboxClaimedRetryWorker>(
    logger
)
{
    private const int CycleDelayInMinutes = 5;
    private const int RetryDelayMinutes = 5;
    private const int BatchCount = 5;

    protected override async Task DoWorkAsync(
        CancellationToken cancellationToken
    )
    {
        var selectClaimedRetryStrategyBuilderArgs =
            new GenericSelectClaimedRetryStrategyBuilderArgs(
                BatchCount,
                RetryDelayMinutes
            );

        var outboxBatchStrategyArgs =
            genericSelectClaimedRetryStrategyBuilder
                .Build<UserToUserChatMessageSendNotificationOutbox>(
                    selectClaimedRetryStrategyBuilderArgs
                );

        var outboxList =
            await
                outboxBatchStrategy
                    .ClaimBatchAsync(
                        outboxBatchStrategyArgs
                    );

        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        foreach (var outbox in outboxList)
        {
            var message =
                new MessageReceivedMessage(
                    outbox.ChatId,
                    outbox.InitiatorUserId,
                    outbox.MessageId,
                    outbox.MessageValue,
                    outbox.MessageCreatedAt
                );

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await
                userToUserChatNotificationsHubService
                    .NotifyMessageReceived(
                        outbox.TargetUserId,
                        message
                    );

            await
                outboxBatchStrategy
                    .MakeDoneAsync(
                        outbox
                    );
        }
    }

    protected override TimeSpan GetDelay() =>
        TimeSpan
            .FromMinutes(
                CycleDelayInMinutes
            );
}