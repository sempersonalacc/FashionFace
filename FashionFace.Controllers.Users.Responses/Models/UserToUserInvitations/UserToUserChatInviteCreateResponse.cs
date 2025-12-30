using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationCreateResponse(
    Guid InvitationId,
    ChatInvitationStatus Status
);