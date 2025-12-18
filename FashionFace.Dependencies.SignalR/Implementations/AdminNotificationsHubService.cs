using System;
using System.Threading.Tasks;

using FashionFace.Common.Constants.Constants;
using FashionFace.Dependencies.SignalR.Interfaces;
using FashionFace.Dependencies.SignalR.Models;

using Microsoft.AspNetCore.SignalR;

namespace FashionFace.Dependencies.SignalR.Implementations;

public sealed class AdminNotificationsHubService(
    IHubContext<AdminNotificationHub, IAdminNotificationApi> adminNotificationHubContext
) : IAdminNotificationsHubService
{
    private const string GroupName = nameof(UserRoleConstants.Admin);

    public async Task Notify(
        Guid userId,
        NotificationMessage message
    ) =>
        await
            adminNotificationHubContext
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
            adminNotificationHubContext
                .Clients
                .Group(
                    GroupName
                )
                .NotificationReceived(
                    message
                );
}