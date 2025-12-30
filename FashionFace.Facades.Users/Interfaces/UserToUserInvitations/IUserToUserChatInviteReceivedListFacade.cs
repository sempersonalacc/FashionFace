using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Models.UserToUserInvitations;

namespace FashionFace.Facades.Users.Interfaces.UserToUserInvitations;

public interface IUserToUserChatInvitationReceivedListFacade :
    IQueryFacade
    <
        UserToUserChatInvitationReceivedListArgs,
        ListResult<UserToUserChatInvitationReceivedListItemResult>>;