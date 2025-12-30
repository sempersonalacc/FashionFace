using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatMessageSendArgs(
    Guid UserId,
    Guid ChatId,
    string Message
);