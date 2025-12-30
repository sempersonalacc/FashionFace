using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationCancelArgs(
    Guid UserId,
    Guid InvitationId
);