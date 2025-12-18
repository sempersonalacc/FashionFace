namespace FashionFace.Dependencies.SignalR.Models;

public sealed record UserNotificationEventModel<TData>(
    string Code,
    TData Data
) where TData : UserNotificationEventDataModel;