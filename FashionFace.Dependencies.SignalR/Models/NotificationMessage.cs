namespace FashionFace.Dependencies.SignalR.Models;

public sealed record NotificationMessage(
    string Code,
    object Data
);