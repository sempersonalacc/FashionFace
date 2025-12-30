using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvites;

public sealed record UserToUserChatInviteSentListItemResponse(
    Guid InviteId,
    Guid TargetUserId
);