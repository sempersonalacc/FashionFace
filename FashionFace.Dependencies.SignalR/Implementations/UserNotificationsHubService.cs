using System;
using System.Threading.Tasks;

using FashionFace.Common.Constants.Constants;
using FashionFace.Dependencies.SignalR.Interfaces;
using FashionFace.Dependencies.SignalR.Models;

using Microsoft.AspNetCore.SignalR;

namespace FashionFace.Dependencies.SignalR.Implementations;

public sealed class UserNotificationsHubService(
    IHubContext<UserNotificationHub, IUserNotificationApi> userNotificationHubContext
) : IUserNotificationsHubService
{
    private const string GroupName = nameof(UserRoleConstants.User);

    public async Task Notify(
        Guid userId,
        NotificationMessage message
    ) =>
        await
            userNotificationHubContext
                .Clients
                .User(
                    userId.ToString()
                )
                .NotificationReceived(
                    message
                );

    public async Task NotifyEveryone(
        NotificationMessage message
    ) =>
        await
            userNotificationHubContext
                .Clients
                .Group(
                    GroupName
                )
                .NotificationReceived(
                    message
                );
}