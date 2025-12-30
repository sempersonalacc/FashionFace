using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationRejectedListArgs(
    Guid UserId,
    int Offset,
    int Limit
);