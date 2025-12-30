using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvites;

public sealed record UserToUserChatInviteResult(
    Guid InviteId,
    Guid InitiatorUserId,
    Guid TargetUserId,
    string Message
);