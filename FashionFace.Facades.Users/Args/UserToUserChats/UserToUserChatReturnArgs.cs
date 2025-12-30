using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatReturnArgs(
    Guid UserId,
    Guid ChatId
);