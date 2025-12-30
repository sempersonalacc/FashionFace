using System.Linq;
using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Base.Responses.Models;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.UserToUserChats;
using FashionFace.Controllers.Users.Responses.Models.UserToUserChats;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.UserToUserChats;
using FashionFace.Facades.Users.Interfaces.UserToUserChats;
using FashionFace.Facades.Users.Models.UserToUserChats;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.UserToUserChats;

[UserControllerGroup(
    "UserToUserChat"
)]
[Route(
    "api/v1/user-to-user-chat/left/list"
)]
public sealed class UserToUserChatLeftListController(
    IUserToUserChatLeavedListFacade facade
) : BaseUserController
{
    [HttpGet]
    public async Task<ListResponse<UserToUserChatLeftListItemResponse>> Invoke(
        [FromQuery] UserToUserChatLeftListRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatLeftListArgs(
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

    private static ListResponse<UserToUserChatLeftListItemResponse> GetResponse(
        ListResult<UserToUserChatLeftListItemResult> result
    )
    {
        var responseList =
            result
                .ItemList
                .Select(
                    entity =>
                        new UserToUserChatLeftListItemResponse(
                            entity.ChatId,
                            entity.UserId
                        )
                )
                .ToList();

        var response =
            new ListResponse<UserToUserChatLeftListItemResponse>(
                result.TotalCount,
                responseList
            );

        return
            response;
    }
}