using System.Threading.Tasks;

using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;
using FashionFace.Facades.Users.Models.UserToUserInvites;
using FashionFace.Repositories.Read.Interfaces;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvites;

public sealed class UserToUserChatInviteCreateFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatInviteCreateFacade
{
    public async Task<UserToUserChatInviteCreateResult> Execute(
        UserToUserChatInviteCreateArgs args
    )
    {
        var (userId, targetUserId, message) = args;
        throw new System.NotImplementedException();
    }
}