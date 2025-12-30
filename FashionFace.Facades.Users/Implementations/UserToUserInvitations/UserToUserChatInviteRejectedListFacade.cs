using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Interfaces.UserToUserInvitations;
using FashionFace.Facades.Users.Models.UserToUserInvitations;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvitations;

public sealed class UserToUserChatInvitationRejectedListFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatInvitationRejectedListFacade
{
    public async Task<ListResult<UserToUserChatInvitationRejectedListItemResult>> Execute(
        UserToUserChatInvitationRejectedListArgs args
    )
    {
        var (userId, offset, limit) = args;

        var userToUserChatInvitationCollection =
            genericReadRepository.GetCollection<UserToUserChatInvitation>();

        Expression<Func<UserToUserChatInvitation, bool>> predicate =
            entity =>
                entity.TargetUserId == userId
                && entity.Status == ChatInvitationStatus.Rejected;

        var totalCount =
            await
                userToUserChatInvitationCollection
                    .CountAsync(
                        predicate
                    );

        var userToUserChatInvitationList =
            await
                userToUserChatInvitationCollection
                    .Where(
                        predicate
                    )
                    .OrderByDescending(
                        entity => entity.CreatedAt
                    )
                    .Select(
                        entity =>
                            new UserToUserChatInvitationRejectedListItemResult(
                                entity.Id,
                                entity.InitiatorUserId
                            )
                    )
                    .Skip(
                        offset
                    )
                    .Take(
                        limit
                    )
                    .ToListAsync();

        var result =
            new ListResult<UserToUserChatInvitationRejectedListItemResult>(
                totalCount,
                userToUserChatInvitationList
            );

        return
            result;
    }
}