using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationSentListArgs(
    Guid UserId,
    int Offset,
    int Limit
);