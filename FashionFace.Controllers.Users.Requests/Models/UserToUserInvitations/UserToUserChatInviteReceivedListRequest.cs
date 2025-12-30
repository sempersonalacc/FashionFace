namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationReceivedListRequest(
    int Offset,
    int Limit
);