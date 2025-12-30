using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationRejectedListItemResult(
    Guid InvitationId,
    Guid InitiatorUserId
);