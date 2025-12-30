using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationReceivedListItemResponse(
    Guid InvitationId,
    Guid InitiatorUserId
);