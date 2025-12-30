using System;

namespace FashionFace.Facades.Users.Args.UserToUserChats;

public sealed record UserToUserChatLeaveArgs(
    Guid UserId,
    Guid ChatId
);