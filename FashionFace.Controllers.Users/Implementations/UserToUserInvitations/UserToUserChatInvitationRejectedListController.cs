using System.Linq;
using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Base.Responses.Models;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;
using FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserInvitations;
using FashionFace.Facades.Users.Interfaces.UserToUserInvitations;
using FashionFace.Facades.Users.Models.UserToUserInvitations;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserInvitations;

[UserControllerGroup(
    "UserToUserChatInvitation"
)]
[Route(
    "api/v1/user-to-user-chat/invitation/rejected/list"
)]
public sealed class UserToUserChatInvitationRejectedListController(
    IUserToUserChatInvitationRejectedListFacade facade
) : UserControllerBase
{
    [HttpGet]
    public async Task<ListResponse<UserToUserChatInvitationRejectedListItemResponse>> Invoke(
        [FromQuery] UserToUserChatInvitationRejectedListRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationRejectedListArgs(
                userId,
                request.Offset,
                request.Limit
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            GetResponse(
                result
            );

        return
            response;
    }

    private static ListResponse<UserToUserChatInvitationRejectedListItemResponse> GetResponse(
        ListResult<UserToUserChatInvitationRejectedListItemResult> result
    )
    {
        var talentListItemResponseList =
            result
                .ItemList
                .Select(
                    entity =>
                        new UserToUserChatInvitationRejectedListItemResponse(
                            entity.InvitationId,
                            entity.InitiatorUserId
                        )
                )
                .ToList();

        var response =
            new ListResponse<UserToUserChatInvitationRejectedListItemResponse>(
                result.TotalCount,
                talentListItemResponseList
            );

        return
            response;
    }
}