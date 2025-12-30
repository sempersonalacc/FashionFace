using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationAcceptArgs(
    Guid UserId,
    Guid InvitationId
);