using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;
using FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Interfaces.UserToUserInvitations;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserInvitations;

[UserControllerGroup(
    "UserToUserChatInvitation"
)]
[Route(
    "api/v1/user-to-user-chat/invite"
)]
public sealed class UserToUserChatInvitationController(
    IUserToUserChatInvitationFacade facade
) : UserControllerBase
{
    [HttpGet]
    public async Task<UserToUserChatInvitationResponse> Invoke(
        [FromQuery] UserToUserChatInvitationRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationArgs(
                userId,
                request.InvitationId
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserToUserChatInvitationResponse(
                result.InvitationId,
                result.InitiatorUserId,
                result.TargetUserId,
                result.Message
            );

        return
            response;
    }
}