using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;

public sealed record UserToUserChatInviteAcceptRequest(
    Guid InviteId
);