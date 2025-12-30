using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatMessageSendResponse(
    Guid MessageId
);