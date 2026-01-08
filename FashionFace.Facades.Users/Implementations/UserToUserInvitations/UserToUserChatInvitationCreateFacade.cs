using System.Threading.Tasks;

using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Interfaces.UserToUserInvitations;
using FashionFace.Facades.Users.Models.UserToUserInvitations;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.OutboxEntity;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;
using FashionFace.Repositories.Transactions.Interfaces;
using FashionFace.Services.Singleton.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvitations;

public sealed class UserToUserChatInvitationCreateFacade(
    IGenericReadRepository genericReadRepository,
    ICreateRepository createRepository,
    ITransactionManager transactionManager,
    IDateTimePicker dateTimePicker,
    IGuidGenerator guidGenerator
) : IUserToUserChatInvitationCreateFacade
{
    public async Task<UserToUserChatInvitationCreateResult> Execute(
        UserToUserChatInvitationCreateArgs args
    )
    {
        var (userId, targetUserId) = args;

        var userToUserChatInvitationCollection =
            genericReadRepository.GetCollection<UserToUserChatInvitation>();

        var userToUserChatInvitation =
            await
                userToUserChatInvitationCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            (entity.TargetUserId == targetUserId
                                && entity.InitiatorUserId == userId)
                            || (entity.TargetUserId == userId
                                && entity.InitiatorUserId == targetUserId)
                    );

        if (userToUserChatInvitation is not null)
        {
            var existInvitationResult =
                new UserToUserChatInvitationCreateResult(
                    userToUserChatInvitation.Id,
                    userToUserChatInvitation.Status
                );

            return
                existInvitationResult;
        }

        var newUserToUserChatInvitation =
            new UserToUserChatInvitation
            {
                Id = guidGenerator.GetNew(),
                InitiatorUserId = userId,
                TargetUserId = targetUserId,
                Status = ChatInvitationStatus.Created,
                CreatedAt = dateTimePicker.GetUtcNow(),
            };

        var outbox =
            new UserToUserChatInvitationCreatedOutbox
            {
                Id = guidGenerator.GetNew(),
                InvitationId = newUserToUserChatInvitation.Id,
                InitiatorUserId = userId,
                TargetUserId = targetUserId,

                AttemptCount = 0,
                ProcessingStartedAt = null,
                OutboxStatus = OutboxStatus.Pending,
            };

        using var transaction =
            await
                transactionManager.BeginTransaction();

        await
            createRepository
                .CreateAsync(
                    newUserToUserChatInvitation
                );

        await
            createRepository
                .CreateAsync(
                    outbox
                );

        await
            transaction.CommitAsync();

        var result =
            new UserToUserChatInvitationCreateResult(
                newUserToUserChatInvitation.Id,
                newUserToUserChatInvitation.Status
            );

        return
            result;
    }
}