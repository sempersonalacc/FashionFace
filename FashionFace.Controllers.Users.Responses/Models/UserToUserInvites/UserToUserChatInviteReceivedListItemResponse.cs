using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;

public sealed record UserToUserChatInviteReceivedListItemResponse(
    Guid InviteId,
    Guid InitiatorUserId
);