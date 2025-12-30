using System;
using System.Collections.Generic;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record UserToUserChatLeftListItemResponse(
    Guid ChatId,
    IReadOnlyList<Guid> UserIdList
);