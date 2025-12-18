using System.Linq;
using System.Security.Claims;

using Microsoft.AspNetCore.SignalR;

namespace FashionFace.Dependencies.SignalR.Implementations;

public abstract class HubBase<TNotificationApi> :
    Hub<TNotificationApi>
    where TNotificationApi : class
{
    protected string GetConnectionId() =>
        Context.ConnectionId;

    protected static string? GetRole(
        ClaimsPrincipal user
    )
    {
        var userTypeClaim =
            user
                .Claims
                .FirstOrDefault(
                    claim =>
                        claim.Type == ClaimTypes.Role
                );

        if (userTypeClaim is null)
        {
            return null;
        }

        var value =
            userTypeClaim.Value;

        return
            value;
    }
}