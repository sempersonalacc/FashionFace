using System;

namespace FashionFace.Facades.Users.Args.UserToUserInvitations;

public sealed record UserToUserChatInvitationCreateArgs(
    Guid UserId,
    Guid TargetUserId
);