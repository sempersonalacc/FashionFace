using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;
using FashionFace.Facades.Users.Models.UserToUserChats;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserChats;

public sealed class UserToUserChatListFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatListFacade
{
    public async Task<ListResult<UserToUserChatListItemResult>> Execute(
        UserToUserChatListArgs args
    )
    {
        var (userId, offset, limit) = args;

        var userToUserChatCollection =
            genericReadRepository.GetCollection<UserToUserChat>();

        Expression<Func<UserToUserChat, bool>> predicate =
            entity =>
                entity
                    .ProfileCollection
                    .Any(
                        profile =>
                            profile.Status == ChatMemberStatus.Active
                            && profile
                                .Profile!
                                .ApplicationUserId
                            == userId
                    );

        var totalCount =
            await
                userToUserChatCollection
                    .CountAsync(
                        predicate
                    );

        var userToUserChatList =
            await
                userToUserChatCollection
                    .Where(
                        predicate
                    )
                    .OrderByDescending(
                        entity => entity.CreatedAt
                    )
                    .Skip(
                        offset
                    )
                    .Take(
                        limit
                    )
                    .Select(
                        entity =>
                            new UserToUserChatListItemResult(
                                entity.Id,
                                entity
                                    .ProfileCollection
                                    .Select(
                                        profile =>
                                            profile
                                                .Profile!
                                                .ApplicationUserId
                                    )
                                    .ToList()
                            )
                    )
                    .ToListAsync();

        var result =
            new ListResult<UserToUserChatListItemResult>(
                totalCount,
                userToUserChatList
            );

        return
            result;
    }
}