using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvites;

public sealed record UserToUserChatInviteReceivedListItemResult(
    Guid InviteId,
    Guid InitiatorUserId
);