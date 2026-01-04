using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserChats;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserChats;

[UserControllerGroup(
    "UserToUserChat"
)]
[Route(
    "api/v1/user-to-user-chat/leave"
)]
public sealed class UserToUserChatLeaveController(
    IUserToUserChatLeaveFacade facade
) : UserControllerBase
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserToUserChatLeaveRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatLeaveArgs(
                userId,
                request.ChatId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}