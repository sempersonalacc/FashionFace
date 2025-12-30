using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Models.UserToUserInvites;

namespace FashionFace.Facades.Users.Interfaces.UserToUserInvites;

public interface IUserToUserChatInviteReceivedListFacade :
    IQueryFacade
    <
        UserToUserChatInviteReceivedListArgs,
        ListResult<UserToUserChatInviteReceivedListItemResult>
    >;