using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationResponse(
    Guid InvitationId,
    Guid InitiatorUserId,
    Guid TargetUserId,
    string Message
);