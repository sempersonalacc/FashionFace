using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;

public sealed record UserToUserChatInviteResponse(
    Guid InviteId,
    Guid InitiatorUserId,
    Guid TargetUserId,
    string Message
);