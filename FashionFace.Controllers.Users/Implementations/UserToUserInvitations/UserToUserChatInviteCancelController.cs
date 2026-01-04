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
    "api/v1/user-to-user-chat/invite/cancel"
)]
public sealed class UserToUserChatInvitationCancelController(
    IUserToUserChatInvitationCancelFacade facade
) : UserControllerBase
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserToUserChatInvitationCancelRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationCancelArgs(
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