using System;
using System.Collections.Generic;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record UserToUserChatResult(
    Guid ChatId,
    IReadOnlyList<Guid> UserIdList
);