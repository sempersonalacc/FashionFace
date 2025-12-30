using System;

namespace FashionFace.Facades.Users.Models.UserToUserInvites;

public sealed record UserToUserChatInviteAcceptResult(
    Guid ChatId,
    Guid UserId
);