using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteCreateArgs(
    Guid UserId,
    Guid TargetUserId,
    string Message
);