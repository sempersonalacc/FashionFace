namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;

public sealed record UserToUserChatInviteRejectedListRequest(
    int Offset,
    int Limit
);