using System.Threading.Tasks;

using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;
using FashionFace.Facades.Users.Models.UserToUserInvites;
using FashionFace.Repositories.Read.Interfaces;

namespace FashionFace.Facades.Users.Implementations.UserToUserInvites;

public sealed class UserToUserChatInviteReceivedListFacade(
    IGenericReadRepository genericReadRepository
) : IUserToUserChatInviteReceivedListFacade
{
    public async Task<ListResult<UserToUserChatInviteReceivedListItemResult>> Execute(
        UserToUserChatInviteReceivedListArgs args
    )
    {
        var (userId, offset, limit) = args;
        throw new System.NotImplementedException();
    }
}