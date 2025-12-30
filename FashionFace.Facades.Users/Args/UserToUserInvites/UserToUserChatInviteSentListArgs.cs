using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteSentListArgs(
    Guid UserId,
    int Offset,
    int Limit
);