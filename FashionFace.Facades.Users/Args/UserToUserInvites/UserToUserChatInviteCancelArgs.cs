using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvites;

public sealed record UserToUserChatInviteCancelArgs(
    Guid UserId,
    Guid InviteId
);