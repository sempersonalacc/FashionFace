using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatResponse(
    Guid ChatId,
    Guid UserId
);