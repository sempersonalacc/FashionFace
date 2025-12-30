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
    "api/v1/user-to-user-chat/message/send"
)]
public sealed class UserToUserChatMessageSendController(
    IUserToUserChatMessageSendFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task<UserToUserChatMessageSendResponse> Invoke(
        [FromBody] UserToUserChatMessageSendRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatMessageSendArgs(
                userId,
                request.ChatId,
                request.Message
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserToUserChatMessageSendResponse(
                result.MessageId
            );

        return
            response;
    }
}