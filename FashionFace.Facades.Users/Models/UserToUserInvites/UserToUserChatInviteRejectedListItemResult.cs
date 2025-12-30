using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvites;

public sealed record UserToUserChatInviteRejectedListItemResult(
    Guid InviteId,
    Guid InitiatorUserId
);