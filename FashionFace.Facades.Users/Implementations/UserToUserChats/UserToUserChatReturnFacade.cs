using System.Linq;
using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models.UserToUserChats;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.UserToUserChats;

public sealed class UserToUserChatReturnFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor,
    IUpdateRepository updateRepository
) : IUserToUserChatReturnFacade
{
    public async Task Execute(
        UserToUserChatReturnArgs args
    )
    {
        var (userId, chatId) = args;

        var userToUserChatCollection =
            genericReadRepository.GetCollection<UserToUserChat>();

        var userToUserChat =
            await
                userToUserChatCollection

                    .Include(
                        entity => entity.ProfileCollection
                    )
                    .ThenInclude(
                        entity => entity.Profile
                    )

                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == chatId
                            && entity
                                .ProfileCollection
                                .Any(
                                    profile =>
                                        profile
                                            .Profile!
                                            .ApplicationUserId
                                        == userId
                                )
                    );

        if (userToUserChat is null)
        {
            throw exceptionDescriptor.NotFound<UserToUserChat>();
        }

        var userToUserChatProfile =
            userToUserChat
                .ProfileCollection
                .First(
                    entity =>
                        entity
                            .Profile!
                            .ApplicationUserId
                        == userId
                );

        userToUserChatProfile.Status =
            ChatMemberStatus.Active;

        await
            updateRepository
                .UpdateAsync(
                    userToUserChatProfile
                );
    }
}