using System;
using System.Threading.Tasks;

using FashionFace.Dependencies.SignalR.Models;

namespace FashionFace.Dependencies.SignalR.Interfaces;

public interface IUserNotificationsHubService
{
    Task Notify(
        Guid userId,
        NotificationMessage message
    );

    Task NotifyEveryone(
        NotificationMessage message
    );
}