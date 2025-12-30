using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Models.UserToUserChats;

namespace FashionFace.Facades.Users.Interfaces.UserToUserChats;

public interface IUserToUserChatListFacade :
    IQueryFacade
    <
        UserToUserChatListArgs,
        ListResult<UserToUserChatListItemResult>
    >;