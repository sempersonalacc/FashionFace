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
    "api/v1/user-to-user-chat/invite"
)]
public sealed class UserToUserChatInviteController(
    IUserToUserChatInviteFacade facade
) : BaseUserController
{
    [HttpGet]
    public async Task<UserToUserChatInviteResponse> Invoke(
        [FromQuery] UserToUserChatInviteRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInviteArgs(
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
            new UserToUserChatInviteResponse(
                result.InviteId,
                result.InitiatorUserId,
                result.TargetUserId,
                result.Message
            );

        return
            response;
    }
}