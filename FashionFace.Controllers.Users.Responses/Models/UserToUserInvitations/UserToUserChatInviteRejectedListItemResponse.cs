using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationRejectedListItemResponse(
    Guid InvitationId,
    Guid InitiatorUserId
);