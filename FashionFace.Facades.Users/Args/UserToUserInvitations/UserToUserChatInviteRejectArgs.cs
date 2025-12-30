using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationRejectArgs(
    Guid UserId,
    Guid InvitationId
);