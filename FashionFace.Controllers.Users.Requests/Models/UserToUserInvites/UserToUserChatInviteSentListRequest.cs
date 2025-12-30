namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;

public sealed record UserToUserChatInviteSentListRequest(
    int Offset,
    int Limit
);