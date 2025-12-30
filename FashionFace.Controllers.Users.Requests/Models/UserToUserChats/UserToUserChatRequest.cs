using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatRequest(
    Guid ChatId
);