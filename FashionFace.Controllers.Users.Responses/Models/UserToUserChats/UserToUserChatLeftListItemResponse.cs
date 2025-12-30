using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatLeftListItemResponse(
    Guid ChatId,
    Guid UserId
);