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

public sealed class UserToUserChatInvitationRejectFacade(
    IGenericReadRepository genericReadRepository,
    ICreateRepository createRepository,
    ITransactionManager transactionManager,
    IExceptionDescriptor exceptionDescriptor,
    IUpdateRepository updateRepository,
    IGuidGenerator guidGenerator,
    IQueuePublishFacade queuePublishFacade,
    IQueuePublishFacadeCommandBuilder  queuePublishFacadeCommandBuilder,
    IDateTimePicker  dateTimePicker
) : IUserToUserChatInvitationRejectFacade
{
    public async Task Execute(
        UserToUserChatInvitationRejectArgs args
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
                            && entity.TargetUserId == userId
                            && entity.Status == ChatInvitationStatus.Created
                    );

        if (userToUserChatInvitation is null)
        {
            throw exceptionDescriptor.NotFound<UserToUserChatInvitation>();
        }

        userToUserChatInvitation.Status =
            ChatInvitationStatus.Rejected;

        var correlationId =
            guidGenerator.GetNew();

        var outbox =
            new UserToUserChatInvitationRejectedOutbox
            {
                Id = guidGenerator.GetNew(),
                InvitationId = userToUserChatInvitation.Id,
                InitiatorUserId = userId,
                TargetUserId = userToUserChatInvitation.InitiatorUserId,

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
            updateRepository
                .UpdateAsync(
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
            new HandleUserToUserInvitationRejectedOutbox(
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