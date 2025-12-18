using System;
using System.Threading.Tasks;

using FashionFace.Common.Constants.Constants;
using FashionFace.Dependencies.SignalR.Interfaces;

namespace FashionFace.Dependencies.SignalR.Implementations;

public sealed class AdminNotificationHub : HubBase<IAdminNotificationApi>
{
    private const string GroupName = nameof(UserRoleConstants.Admin);

    public override async Task OnConnectedAsync()
    {
        var user =
            Context.User!;

        var role =
            GetRole(
                user
            );

        if (role is null)
        {
            Context.Abort();
            return;
        }

        var isNotAdmin =
            role != GroupName;

        if (isNotAdmin)
        {
            Context.Abort();
            return;
        }

        await
            Groups
                .AddToGroupAsync(
                    GetConnectionId(),
                    GroupName
                );
    }

    public override async Task OnDisconnectedAsync(
        Exception? exception
    )
    {
        await
            Groups
                .RemoveFromGroupAsync(
                    GetConnectionId(),
                    GroupName
                );
    }
}