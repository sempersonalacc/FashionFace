namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationRejectedListRequest(
    int Offset,
    int Limit
);