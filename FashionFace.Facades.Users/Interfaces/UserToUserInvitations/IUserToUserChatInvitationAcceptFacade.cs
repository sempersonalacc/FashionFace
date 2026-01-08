using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Models.UserToUserInvitations;

namespace FashionFace.Facades.Users.Interfaces.UserToUserInvitations;

public interface IUserToUserChatInvitationAcceptFacade :
    IQueryFacade
    <
        UserToUserChatInvitationAcceptArgs,
        UserToUserChatInvitationAcceptResult
    >;