using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationSentListItemResult(
    Guid InvitationId,
    Guid TargetUserId
);