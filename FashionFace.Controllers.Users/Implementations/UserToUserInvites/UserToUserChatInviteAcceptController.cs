using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;
using FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;
using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserInvites;

[UserControllerGroup(
    "UserToUserChatInvite"
)]
[Route(
    "api/v1/user-to-user-chat/invite/accept"
)]
public sealed class UserToUserChatInviteAcceptController(
    IUserToUserChatInviteAcceptFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task<UserToUserChatInviteAcceptResponse> Invoke(
        [FromBody] UserToUserChatInviteAcceptRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInviteAcceptArgs(
                userId,
                request.InviteId
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserToUserChatInviteAcceptResponse(
                result.ChatId,
                result.UserId
            );

        return
            response;
    }
}