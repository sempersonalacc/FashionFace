using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteRejectedListArgs(
    Guid UserId,
    int Offset,
    int Limit
);