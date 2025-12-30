using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;

public sealed record UserToUserChatInviteAcceptResponse(
    Guid ChatId,
    Guid UserId
);