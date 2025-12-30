using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatListItemResponse(
    Guid ChatId,
    Guid UserId
);