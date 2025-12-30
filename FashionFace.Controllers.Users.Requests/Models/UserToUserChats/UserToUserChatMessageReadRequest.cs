using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatMessageReadRequest(
    Guid MessageId
);