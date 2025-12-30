using System;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatListItemResult(
    Guid ChatId,
    Guid UserId
);