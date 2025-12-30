namespace FashionFace.Controllers.Users.Requests.Models.UserToUserInvites;

public sealed record UserToUserChatInviteReceivedListRequest(
    int Offset,
    int Limit
);