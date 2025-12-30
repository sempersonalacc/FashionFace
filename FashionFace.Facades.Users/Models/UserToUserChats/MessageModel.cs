using System;

namespace FashionFace.Facades.Users.Models.UserToUserChats;

public sealed record MessageModel(
    Guid Id,
    string Value
);