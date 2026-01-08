using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
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
    IGuidGenerator guidGenerator
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

        var outbox =
            new UserToUserChatInvitationRejectedOutbox
            {
                Id = guidGenerator.GetNew(),
                InvitationId = userToUserChatInvitation.Id,
                InitiatorUserId = userId,
                TargetUserId = userToUserChatInvitation.TargetUserId,

                AttemptCount = 0,
                ProcessingStartedAt = null,
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
    }
}