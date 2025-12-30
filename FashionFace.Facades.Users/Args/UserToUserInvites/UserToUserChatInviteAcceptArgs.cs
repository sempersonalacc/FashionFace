using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteAcceptArgs(
    Guid UserId,
    Guid InviteId
);