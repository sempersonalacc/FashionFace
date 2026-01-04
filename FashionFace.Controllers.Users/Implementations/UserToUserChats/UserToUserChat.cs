using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserChats;
using FashionFace.Controllers.Users.Responses.Models.UserToUserChats;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserChats;

[UserControllerGroup(
    "UserToUserChat"
)]
[Route(
    "api/v1/user-to-user-chat"
)]
public sealed class UserToUserChatController(
    IUserToUserChatFacade facade
) : UserControllerBase
{
    [HttpGet]
    public async Task<UserToUserChatResponse> Invoke(
        [FromQuery] UserToUserChatRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatArgs(
                userId,
                request.ChatId
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserToUserChatResponse(
                result.ChatId,
                result.UserIdList
            );

        return
            response;
    }
}