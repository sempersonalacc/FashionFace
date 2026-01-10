using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;
using FashionFace.Repositories.Strategy.Builders.Args;
using FashionFace.Repositories.Strategy.Builders.Interfaces;
using FashionFace.Repositories.Strategy.Interfaces;
using FashionFace.Repositories.Transactions.Interfaces;
using FashionFace.Services.Singleton.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FashionFace.Executable.Worker.UserEvents.Workers;

public sealed class UserToUserChatMessageSendOutboxPendingWorker(
    IOutboxBatchStrategy<UserToUserChatMessageSendOutbox> outboxBatchStrategy,
    IGenericSelectPendingStrategyBuilder genericSelectPendingStrategyBuilder,
    IGenericReadRepository genericReadRepository,
    IUpdateRepository updateRepository,
    ITransactionManager  transactionManager,
    IGuidGenerator guidGenerator,
    ILogger<UserToUserChatMessageSendOutboxPendingWorker> logger
) : BaseBackgroundWorker<UserToUserChatMessageSendOutboxPendingWorker>(
    logger
)
{
    private const int CycleDelayInMinutes = 5;
    private const int BatchCount = 5;

    protected override async Task DoWorkAsync(
        CancellationToken cancellationToken
    )
    {
        var selectPendingStrategyBuilderArgs =
            new GenericSelectPendingStrategyBuilderArgs(
                BatchCount
            );

        var outboxBatchStrategyArgs =
            genericSelectPendingStrategyBuilder
                .Build<UserToUserChatMessageSendOutbox>(
                    selectPendingStrategyBuilderArgs
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
            var chatId = outbox.ChatId;
            var messageId = outbox.MessageId;
            var initiatorUserId = outbox.InitiatorUserId;
            var correlationId = outbox.CorrelationId;

            var userToUserChatCollection =
                genericReadRepository.GetCollection<UserToUserChat>();

            var userToUserChat =
                await
                    userToUserChatCollection

                        .Include(
                            entity => entity.UserCollection
                        )

                        .FirstOrDefaultAsync(
                            entity =>
                                entity.Id == chatId
                                && entity
                                    .UserCollection
                                    .Any(
                                        profile =>
                                            profile.ApplicationUserId == initiatorUserId
                                    )
                        );

            if (userToUserChat is null)
            {
                await
                    outboxBatchStrategy
                        .MakeFailedAsync(
                            outbox
                        );

                logger
                    .LogError(
                        $"Outbox [{outbox.Id}] failed. User to user chat [{chatId}] was not found"
                    );

                continue;
            }

            var userToUserChatMessageCollection =
                genericReadRepository.GetCollection<UserToUserChatMessage>();

            var userToUserChatMessage =
                await
                    userToUserChatMessageCollection

                        .Include(
                            entity => entity.Message
                        )

                        .FirstOrDefaultAsync(
                            entity =>
                                entity.MessageId == messageId
                                && entity.ChatId == chatId
                        );

            if (userToUserChatMessage is null)
            {
                await
                    outboxBatchStrategy
                        .MakeFailedAsync(
                            outbox
                        );

                logger
                    .LogError(
                        $"Outbox [{outbox.Id}] failed. User to user chat message [{messageId}] was not found"
                    );

                continue;
            }

            var chatMessage =
                userToUserChatMessage.Message!;

            var message =
                chatMessage.Value;

            var createdAt =
                chatMessage.CreatedAt;

            var userToUserChatMessageSendNotificationOutboxList =
                userToUserChat
                    .UserCollection
                    .Where(
                        entity =>
                            entity.ApplicationUserId != initiatorUserId
                    )
                    .Select(
                        entity => entity.ApplicationUserId
                    )
                    .Select(
                        targetUserId =>
                            new UserToUserChatMessageSendNotificationOutbox
                            {
                                Id = guidGenerator.GetNew(),
                                ChatId = chatId,
                                MessageId = messageId,
                                MessageValue = message,
                                MessageCreatedAt = createdAt,
                                InitiatorUserId = initiatorUserId,
                                TargetUserId = targetUserId,

                                CorrelationId = correlationId,
                                AttemptCount = 0,
                                OutboxStatus = OutboxStatus.Pending,
                                ClaimedAt = null,
                            }
                    )
                    .ToList();

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            using var transaction =
                await
                    transactionManager.BeginTransaction();

            await
                updateRepository
                    .UpdateCollectionAsync(
                        userToUserChatMessageSendNotificationOutboxList,
                        cancellationToken
                    );

            await
                outboxBatchStrategy
                    .MakeDoneAsync(
                        outbox
                    );

            await
                transaction.CommitAsync();
        }
    }

    protected override TimeSpan GetDelay() =>
        TimeSpan
            .FromMinutes(
                CycleDelayInMinutes
            );
}