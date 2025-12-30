using System;

using FashionFace.Repositories.Context.Enums;

namespace FashionFace.Facades.Users.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationCreateResult(
    Guid InvitationId,
    ChatInvitationStatus Status
);