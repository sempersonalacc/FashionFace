using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationCancelRequest(
    Guid InvitationId
);