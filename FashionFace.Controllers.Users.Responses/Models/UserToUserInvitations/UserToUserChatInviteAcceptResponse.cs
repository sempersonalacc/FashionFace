using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationAcceptResponse(
    Guid ChatId,
    Guid UserId
);