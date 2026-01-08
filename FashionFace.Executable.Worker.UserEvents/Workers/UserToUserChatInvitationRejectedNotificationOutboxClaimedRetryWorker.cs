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

public sealed class UserToUserChatInvitationRejectedNotificationOutboxClaimedRetryWorker(
    IUserToUserChatInvitationNotificationsHubService userToUserChatInvitationNotificationsHubService,
    IOutboxBatchStrategy<UserToUserChatInvitationRejectedOutbox> outboxBatchStrategy,
    ISelectClaimedRetryStrategyBuilder selectClaimedRetryStrategyBuilder,
    ILogger<UserToUserChatInvitationRejectedNotificationOutboxClaimedRetryWorker> logger
) : BaseBackgroundWorker<UserToUserChatInvitationRejectedNotificationOutboxClaimedRetryWorker>(
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
                .Build<UserToUserChatInvitationRejectedOutbox>(
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
                new InvitationRejectedMessage(
                    outbox.InvitationId,
                    outbox.TargetUserId
                );

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await
                userToUserChatInvitationNotificationsHubService
                    .NotifyInvitationRejected(
                        outbox.InitiatorUserId,
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
            .FromSeconds(
                CycleDelayInSeconds
            );
}