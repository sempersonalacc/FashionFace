using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatListArgs(
    Guid UserId,
    int Offset,
    int Limit
);