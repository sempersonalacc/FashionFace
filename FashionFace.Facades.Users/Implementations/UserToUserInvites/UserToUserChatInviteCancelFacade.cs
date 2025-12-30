using System.Threading.Tasks;

using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;
using FashionFace.Repositories.Read.Interfaces;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvites;

public sealed class UserToUserChatInviteCancelFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatInviteCancelFacade
{
    public async Task Execute(
        UserToUserChatInviteCancelArgs args
    )
    {
        var (userId, inviteId) = args;
        throw new System.NotImplementedException();
    }
}