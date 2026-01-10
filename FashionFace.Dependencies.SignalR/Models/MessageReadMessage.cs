using System;

namespace FashionFace.Dependencies.SignalR.Models;

public sealed record MessageReadMessage(
    Guid ChatId,
    Guid InitiatorUserId,
    Guid MessageId
);