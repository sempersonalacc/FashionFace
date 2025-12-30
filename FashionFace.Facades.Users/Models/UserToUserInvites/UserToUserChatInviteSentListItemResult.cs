using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvites;

public sealed record UserToUserChatInviteSentListItemResult(
    Guid InviteId,
    Guid TargetUserId
);