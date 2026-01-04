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
    "api/v1/user-to-user-chat/invite/create"
)]
public sealed class UserToUserChatInvitationCreateController(
    IUserToUserChatInvitationCreateFacade facade
) : UserControllerBase
{
    [HttpPost]
    public async Task<UserToUserChatInvitationCreateResponse> Invoke(
        [FromBody] UserToUserChatInvitationCreateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationCreateArgs(
                userId,
                request.UserId
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserToUserChatInvitationCreateResponse(
                result.InvitationId,
                result.Status
            );

        return
            response;
    }
}