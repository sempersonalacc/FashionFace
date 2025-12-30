using System;
using System.Collections.Generic;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatLeftListItemResult(
    Guid ChatId,
    IReadOnlyList<Guid> UserIdList
);