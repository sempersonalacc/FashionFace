using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatLeftListArgs(
    Guid UserId,
    int Offset,
    int Limit
);