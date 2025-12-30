using System;
using System.Collections.Generic;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatResponse(
    Guid ChatId,
    IReadOnlyList<Guid> UserIdList
);