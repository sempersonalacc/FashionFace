namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvitations;

public sealed record UserToUserChatInvitationSentListRequest(
    int Offset,
    int Limit
);