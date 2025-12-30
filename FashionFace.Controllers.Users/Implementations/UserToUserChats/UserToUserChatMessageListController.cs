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
    "api/v1/user-to-user-chat/message/list"
)]
public sealed class UserToUserChatMessageListController(
    IUserToUserChatMessageListFacade facade
) : BaseUserController
{
    [HttpGet]
    public async Task<ListResponse<UserToUserChatMessageListItemResponse>> Invoke(
        [FromQuery] UserToUserChatMessageListRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserToUserChatMessageListArgs(
                userId,
                request.ChatId,
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

    private static ListResponse<UserToUserChatMessageListItemResponse> GetResponse(
        ListResult<UserToUserChatMessageListItemResult> result
    )
    {
        var responseList =
            result
                .ItemList
                .Select(
                    entity =>
                        new UserToUserChatMessageListItemResponse(
                            entity.UserId,
                            new(
                                entity.Message.Id,
                                entity.Message.Value
                            )
                        )
                )
                .ToList();

        var response =
            new ListResponse<UserToUserChatMessageListItemResponse>(
                result.TotalCount,
                responseList
            );

        return
            response;
    }
}