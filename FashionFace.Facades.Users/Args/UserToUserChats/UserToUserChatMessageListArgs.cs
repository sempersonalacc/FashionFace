using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatMessageListArgs(
    Guid UserId,
    Guid ChatId,
    int Offset,
    int Limit
);