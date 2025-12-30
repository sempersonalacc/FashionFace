using System;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatLeftListItemResult(
    Guid ChatId,
    Guid UserId
);