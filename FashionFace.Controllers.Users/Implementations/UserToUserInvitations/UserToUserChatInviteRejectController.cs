using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Interfaces.UserToUserInvitations;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserInvitations;

[UserControllerGroup(
    "UserToUserChatInvitation"
)]
[Route(
    "api/v1/user-to-user-chat/invite/reject"
)]
public sealed class UserToUserChatInvitationRejectController(
    IUserToUserChatInvitationRejectFacade facade
) : UserControllerBase
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserToUserChatInvitationRejectRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationRejectArgs(
                userId,
                request.InvitationId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}