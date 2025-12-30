using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;

public sealed record UserToUserChatInviteCreateRequest(
    Guid UserId,
    string Message
);