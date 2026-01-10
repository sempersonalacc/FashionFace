using System.Linq;
using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Common.Models.Models.Commands;
using FashionFace.Dependencies.RabbitMq.Facades.Interfaces;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;
using FashionFace.Facades.Users.Models.UserToUserChats;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;
using FashionFace.Repositories.Transactions.Interfaces;
using FashionFace.Services.Singleton.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserChats;

public sealed class UserToUserChatMessageSendFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor,
    ICreateRepository createRepository,
    ITransactionManager  transactionManager,
    IDateTimePicker dateTimePicker,
    IGuidGenerator guidGenerator,
    IQueuePublishFacade queuePublishFacade,
    IQueuePublishFacadeCommandBuilder  queuePublishFacadeCommandBuilder
) : IUserToUserChatMessageSendFacade
{
    public async Task<UserToUserChatMessageSendResult> Execute(
        UserToUserChatMessageSendArgs args
    )
    {
        var (userId, chatId, message) = args;

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
                                        profile.ApplicationUserId == userId
                                )
                    );

        if (userToUserChat is null)
        {
            throw exceptionDescriptor.NotFound<UserToUserChat>();
        }

        var messageId =
            guidGenerator.GetNew();

        var createdAt =
            dateTimePicker.GetUtcNow();

        var userToUserMessage =
            new UserToUserMessage
            {
                Id = messageId,
                ApplicationUserId = userId,
                Value =  message,
                CreatedAt =  createdAt,
            };

        var userToUserChatMessage =
            new UserToUserChatMessage
            {
                Id = guidGenerator.GetNew(),
                ChatId = chatId,
                MessageId = messageId,
                Message = userToUserMessage,
                CreatedAt = createdAt,
            };

        var correlationId =
            guidGenerator.GetNew();

        var outbox =
            new UserToUserChatMessageSendOutbox
            {
                Id = guidGenerator.GetNew(),
                ChatId = chatId,
                MessageId = messageId,
                InitiatorUserId = userId,

                CorrelationId = correlationId,
                AttemptCount = 0,
                OutboxStatus = OutboxStatus.Pending,
                ClaimedAt = null,
            };

        using var transaction =
            await
                transactionManager.BeginTransaction();

        await
            createRepository
                .CreateAsync(
                    userToUserChatMessage
                );

        await
            createRepository
                .CreateAsync(
                    outbox
                );

        await
            transaction.CommitAsync();

        var handleOutbox =
            new HandleUserToUserMessageSendOutbox(
                outbox.CorrelationId
            );

        var queuePublishFacadeArgs =
            queuePublishFacadeCommandBuilder
                .Build(
                    handleOutbox
                );

        await
            queuePublishFacade
                .PublishAsync(
                    queuePublishFacadeArgs
                );

        var result =
            new UserToUserChatMessageSendResult(
                messageId
            );

        return
            result;
    }
}