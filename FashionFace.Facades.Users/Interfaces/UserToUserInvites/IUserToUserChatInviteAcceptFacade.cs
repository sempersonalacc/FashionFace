using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Models.UserToUserInvites;

namespace FashionFace.Facades.Users.Interfaces.UserToUserInvites;

public interface IUserToUserChatInviteAcceptFacade :
    IQueryFacade
    <
        UserToUserChatInviteAcceptArgs,
        UserToUserChatInviteAcceptResult
    >;