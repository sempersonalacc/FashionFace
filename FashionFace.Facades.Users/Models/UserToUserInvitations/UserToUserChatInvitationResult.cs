using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationResult(
    Guid InvitationId,
    Guid InitiatorUserId,
    Guid TargetUserId,
    string Message
);