using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Base.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations;

[UserControllerGroup(
    "Users"
)]
[Route(
    "api/v1/user/password/set"
)]
public sealed class UserPasswordSetController(
    IUserPasswordSetFacade facade
) : BaseAuthorizeController
{
    [HttpPatch]
    public async Task Invoke(
        [FromBody] UserPasswordSetRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPasswordSetArgs(
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