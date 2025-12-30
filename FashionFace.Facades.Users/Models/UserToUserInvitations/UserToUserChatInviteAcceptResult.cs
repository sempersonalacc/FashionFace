using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationAcceptResult(
    Guid ChatId,
    Guid UserId
);