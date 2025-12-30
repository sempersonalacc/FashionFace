namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatLeftListRequest(
    int Offset,
    int Limit
);