using System;

namespace FashionFace.Controllers.Users.Responses.Models.UserToUserChats;

public sealed record MessageResponse(
    Guid Id,
    string Value
);