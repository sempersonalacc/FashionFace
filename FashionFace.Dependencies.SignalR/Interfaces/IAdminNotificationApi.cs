using System.Threading.Tasks;

using FashionFace.Dependencies.SignalR.Models;

namespace FashionFace.Dependencies.SignalR.Interfaces;

public interface IAdminNotificationApi
{
    Task NotificationReceived(
        NotificationMessage message
    );
}