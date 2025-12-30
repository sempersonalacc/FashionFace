using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatMessageListItemResponse(
    Guid UserId,
    string Value
);