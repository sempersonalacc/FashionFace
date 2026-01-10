using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Common.Models.Models.Commands;
using FashionFace.Dependencies.RabbitMq.Facades.Interfaces;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Interfaces.UserToUserInvitations;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;
using FashionFace.Repositories.Transactions.Interfaces;
using FashionFace.Services.Singleton.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvitations;

public sealed class UserToUserChatInvitationCancelFacade(
    IGenericReadRepository genericReadRepository,
    ICreateRepository createRepository,
    ITransactionManager transactionManager,
    IExceptionDescriptor exceptionDescriptor,
    IDeleteRepository deleteRepository,
    IGuidGenerator guidGenerator,
    IQueuePublishFacade queuePublishFacade,
    IQueuePublishFacadeCommandBuilder  queuePublishFacadeCommandBuilder,
    IDateTimePicker dateTimePicker
) : IUserToUserChatInvitationCancelFacade
{
    public async Task Execute(
        UserToUserChatInvitationCancelArgs args
    )
    {
        var (userId, invitationId) = args;

        var userToUserChatInvitationCollection =
            genericReadRepository.GetCollection<UserToUserChatInvitation>();

        var userToUserChatInvitation =
            await
                userToUserChatInvitationCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == invitationId
                            && entity.InitiatorUserId == userId
                            && entity.Status == ChatInvitationStatus.Created
                    );

        if (userToUserChatInvitation is null)
        {
            throw exceptionDescriptor.NotFound<UserToUserChatInvitation>();
        }

        var correlationId =
            guidGenerator.GetNew();

        var outbox =
            new UserToUserChatInvitationCanceledOutbox
            {
                Id = guidGenerator.GetNew(),
                InvitationId = userToUserChatInvitation.Id,
                InitiatorUserId = userId,
                TargetUserId = userToUserChatInvitation.TargetUserId,

                CreatedAt = dateTimePicker.GetUtcNow(),
                CorrelationId = correlationId,
                AttemptCount = 0,
                ClaimedAt = null,
                OutboxStatus = OutboxStatus.Pending,
            };

        using var transaction =
            await
                transactionManager.BeginTransaction();

        await
            deleteRepository
                .DeleteAsync(
                    userToUserChatInvitation
                );

        await
            createRepository
                .CreateAsync(
                    outbox
                );

        await
            transaction.CommitAsync();

        var handleOutbox =
            new HandleUserToUserInvitationCanceledOutbox(
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
    }
}