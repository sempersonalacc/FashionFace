using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationSentListItemResponse(
    Guid InvitationId,
    Guid TargetUserId
);