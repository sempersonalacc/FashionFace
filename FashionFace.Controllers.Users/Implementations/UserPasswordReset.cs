using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations;

[UserControllerGroup(
    "Users"
)]
[Route(
    "api/v1/user/password/reset"
)]
public sealed class UserPasswordResetController(
    IUserPasswordResetFacade facade
) : UserControllerBase
{
    [HttpPatch]
    public async Task Invoke(
        [FromBody] UserPasswordResetRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPasswordResetArgs(
                userId,
                request.OldPassword,
                request.NewPassword
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}