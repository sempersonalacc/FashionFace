using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteRejectArgs(
    Guid UserId,
    Guid InviteId
);