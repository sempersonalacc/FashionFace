using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatReturnRequest(
    Guid ChatId
);