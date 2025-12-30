using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationReceivedListItemResult(
    Guid InvitationId,
    Guid InitiatorUserId
);