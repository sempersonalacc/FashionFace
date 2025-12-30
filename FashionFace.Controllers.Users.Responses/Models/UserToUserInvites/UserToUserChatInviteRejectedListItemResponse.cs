using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;

public sealed record UserToUserChatInviteRejectedListItemResponse(
    Guid InviteId,
    Guid InitiatorUserId
);