using System;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatMessageListItemResult(
    Guid UserId,
    MessageModel Message
);