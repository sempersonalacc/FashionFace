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
    "api/v1/user-to-user-chat/invitation/accept"
)]
public sealed class UserToUserChatInvitationAcceptController(
    IUserToUserChatInvitationAcceptFacade facade
) : UserControllerBase
{
    [HttpPost]
    public async Task<UserToUserChatInvitationAcceptResponse> Invoke(
        [FromBody] UserToUserChatInvitationAcceptRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationAcceptArgs(
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
            new UserToUserChatInvitationAcceptResponse(
                result.ChatId,
                result.UserId
            );

        return
            response;
    }
}