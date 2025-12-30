using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatArgs(
    Guid UserId,
    Guid ChatId
);