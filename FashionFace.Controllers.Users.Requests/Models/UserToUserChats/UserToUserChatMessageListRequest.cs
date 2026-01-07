using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatMessageListRequest(
    Guid ChatId,
    DateTime? Before
);