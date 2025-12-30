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
    "api/v1/user-to-user-chat/invite/received/list"
)]
public sealed class UserToUserChatInvitationReceivedListController(
    IUserToUserChatInvitationReceivedListFacade facade
) : BaseUserController
{
    [HttpGet]
    public async Task<ListResponse<UserToUserChatInvitationReceivedListItemResponse>> Invoke(
        [FromQuery] UserToUserChatInvitationReceivedListRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInvitationReceivedListArgs(
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

    private static ListResponse<UserToUserChatInvitationReceivedListItemResponse> GetResponse(
        ListResult<UserToUserChatInvitationReceivedListItemResult> result
    )
    {
        var talentListItemResponseList =
            result
                .ItemList
                .Select(
                    entity =>
                        new UserToUserChatInvitationReceivedListItemResponse(
                            entity.InvitationId,
                            entity.InitiatorUserId
                        )
                )
                .ToList();

        var response =
            new ListResponse<UserToUserChatInvitationReceivedListItemResponse>(
                result.TotalCount,
                talentListItemResponseList
            );

        return
            response;
    }
}