using System;

namespace FashionFace.Controllers.Users.Requests.Models.UserToUserChats;

public sealed record UserToUserChatLeaveRequest(
    Guid ChatId
);