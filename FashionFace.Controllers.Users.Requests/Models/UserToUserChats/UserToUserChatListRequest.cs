namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatListRequest(
    int Offset,
    int Limit
);