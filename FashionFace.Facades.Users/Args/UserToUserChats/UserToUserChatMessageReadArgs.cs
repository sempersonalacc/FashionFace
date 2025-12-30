using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatMessageReadArgs(
    Guid UserId,
    Guid MessageId
);