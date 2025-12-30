using System;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatResult(
    Guid ChatId,
    Guid UserId
);