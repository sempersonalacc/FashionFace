using System.Threading.Tasks;

using FashionFace.Dependencies.SignalR.Interfaces;
using FashionFace.Dependencies.SignalR.Models;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Strategy.Args;
using FashionFace.Repositories.Strategy.Interfaces;

using Microsoft.Extensions.Logging;

namespace FashionFace.Executable.Worker.UserEvents.Workers;

public sealed class UserToUserChatMessageOutboxWorker(
    IUserToUserChatNotificationsHubService userToUserChatNotificationsHubService,
    IOutboxBatchStrategy<UserToUserChatMessageOutbox> outboxBatchStrategy,
    ISelectPendingStrategyBuilder selectPendingStrategyBuilder,
    ILogger<UserToUserChatMessageOutboxWorker> logger
) : BaseBackgroundWorker<UserToUserChatMessageOutboxWorker>(
    logger
)
{
    private const int BatchCount = 5;

    protected override async Task DoWorkAsync()
    {
        var selectPendingStrategyBuilderArgs =
            new SelectPendingStrategyBuilderArgs(
                BatchCount
            );

        var postgresOutboxBatchStrategyArgs =
            selectPendingStrategyBuilder
                .Build<UserToUserChatMessageOutbox>(
                    selectPendingStrategyBuilderArgs
                );

        var userToUserChatMessageOutboxList =
            await
                outboxBatchStrategy
                    .ClaimBatchAsync(
                        postgresOutboxBatchStrategyArgs
                    );

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
}