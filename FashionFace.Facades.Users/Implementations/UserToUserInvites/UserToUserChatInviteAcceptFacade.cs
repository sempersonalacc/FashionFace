using System.Threading.Tasks;

using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;
using FashionFace.Facades.Users.Models.UserToUserInvites;
using FashionFace.Repositories.Read.Interfaces;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvites;

public sealed class UserToUserChatInviteAcceptFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatInviteAcceptFacade
{
    public async Task<UserToUserChatInviteAcceptResult> Execute(
        UserToUserChatInviteAcceptArgs args
    )
    {
        var (userId, inviteId) = args;
        throw new System.NotImplementedException();
    }
}