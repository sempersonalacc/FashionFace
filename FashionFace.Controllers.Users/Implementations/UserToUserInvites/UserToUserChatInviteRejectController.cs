using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;
using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserInvites;

[UserControllerGroup(
    "UserToUserChatInvite"
)]
[Route(
    "api/v1/user-to-user-chat/invite/reject"
)]
public sealed class UserToUserChatInviteRejectController(
    IUserToUserChatInviteRejectFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserToUserChatInviteRejectRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInviteRejectArgs(
                userId,
                request.InviteId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}