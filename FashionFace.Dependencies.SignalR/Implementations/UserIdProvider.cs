using System.Linq;
using System.Security.Claims;

using FashionFace.Common.Exceptions.Interfaces;

using Microsoft.AspNetCore.SignalR;

namespace FashionFace.Dependencies.SignalR.Implementations;

public sealed class UserIdProvider(
    IExceptionDescriptor exceptionDescriptor
) : IUserIdProvider
{
    public string GetUserId(
        HubConnectionContext connection
    )
    {
        var userIdString =
            GetClaimValue(
                connection,
                ClaimTypes.NameIdentifier
            );

        return
            userIdString;
    }

    private string GetClaimValue(
        HubConnectionContext connection,
        string claimType
    )
    {
        var claimValue =
            connection
                .User
                .Claims
                .FirstOrDefault(
                    claim =>
                        claim.Type == claimType
                )
                ?.Value;

        if (claimValue is null)
        {
            throw exceptionDescriptor.Unauthorized();
        }

        return
            claimValue;
    }
}