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
    "api/v1/user-to-user-chat/message/read"
)]
public sealed class UserToUserChatMessageReadController(
    IUserToUserChatMessageReadFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserToUserChatMessageReadRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatMessageReadArgs(
                userId,
                request.MessageId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}