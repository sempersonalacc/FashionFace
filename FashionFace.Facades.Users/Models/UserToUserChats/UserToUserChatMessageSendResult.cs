using System;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatMessageSendResult(
    Guid MessageId
);