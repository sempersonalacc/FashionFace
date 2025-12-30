using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatMessageSendRequest(
    Guid ChatId,
    string Message
);