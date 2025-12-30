using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationReceivedListArgs(
    Guid UserId,
    int Offset,
    int Limit
);