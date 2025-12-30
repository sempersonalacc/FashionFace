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

public sealed class UserToUserChatLeftListFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatLeftListFacade
{
    public async Task<ListResult<UserToUserChatLeftListItemResult>> Execute(
        UserToUserChatLeftListArgs args
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
                            profile.Status == ChatMemberStatus.Left
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
                            new UserToUserChatLeftListItemResult(
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
            new ListResult<UserToUserChatLeftListItemResult>(
                totalCount,
                userToUserChatList
            );

        return
            result;
    }
}