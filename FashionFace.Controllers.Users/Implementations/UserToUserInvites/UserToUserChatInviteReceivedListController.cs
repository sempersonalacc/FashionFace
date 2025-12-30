using System.Linq;
using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Base.Responses.Models;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;
using FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserInvites;
using FashionFace.Facades.Users.Interfaces.UserToUserInvites;
using FashionFace.Facades.Users.Models.UserToUserInvites;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserInvites;

[UserControllerGroup(
    "UserToUserChatInvite"
)]
[Route(
    "api/v1/user-to-user-chat/invite/received/list"
)]
public sealed class UserToUserChatInviteReceivedListController(
    IUserToUserChatInviteReceivedListFacade facade
) : BaseUserController
{
    [HttpGet]
    public async Task<ListResponse<UserToUserChatInviteReceivedListItemResponse>> Invoke(
        [FromQuery] UserToUserChatInviteReceivedListRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatInviteReceivedListArgs(
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

    private static ListResponse<UserToUserChatInviteReceivedListItemResponse> GetResponse(
        ListResult<UserToUserChatInviteReceivedListItemResult> result
    )
    {
        var talentListItemResponseList =
            result
                .ItemList
                .Select(
                    entity =>
                        new UserToUserChatInviteReceivedListItemResponse(
                            entity.InviteId,
                            entity.InitiatorUserId
                        )
                )
                .ToList();

        var response =
            new ListResponse<UserToUserChatInviteReceivedListItemResponse>(
                result.TotalCount,
                talentListItemResponseList
            );

        return
            response;
    }
}