using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationArgs(
    Guid UserId,
    Guid InvitationId
);