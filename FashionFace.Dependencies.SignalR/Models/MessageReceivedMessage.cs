using System;

namespace FashionFace.Dependencies.SignalR.Models;

public sealed record MessageReceivedMessage(
    Guid ChatId,
    Guid InitiatorUserId,
    Guid MessageId,
    string MessageValue,
    DateTime MessageCreatedAt
);