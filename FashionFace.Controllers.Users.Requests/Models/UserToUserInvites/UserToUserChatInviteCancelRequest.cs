using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;

public sealed record UserToUserChatInviteCancelRequest(
    Guid InviteId
);