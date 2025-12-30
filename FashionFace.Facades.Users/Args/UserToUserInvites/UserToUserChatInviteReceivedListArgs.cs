using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteReceivedListArgs(
    Guid UserId,
    int Offset,
    int Limit
);