using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteArgs(
    Guid UserId,
    Guid InviteId
);