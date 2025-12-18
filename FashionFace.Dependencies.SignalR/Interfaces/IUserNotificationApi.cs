using System.Threading.Tasks;

using FashionFace.Dependencies.SignalR.Models;

namespace FashionFace.Dependencies.SignalR.Interfaces;

public interface IUserNotificationApi
{
    Task NotificationReceived(
        NotificationMessage message
    );
}