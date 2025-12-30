using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationRejectRequest(
    Guid InvitationId
);