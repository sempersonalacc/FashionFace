using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations;

[UserControllerGroup(
    "Profile"
)]
[Route(
    "api/v1/user/profile"
)]
public sealed class UserProfileDeleteController(
    IUserProfileDeleteFacade facade
) : BaseUserController
{
    [HttpDelete]
    public async Task Invoke(
        [FromBody] UserProfileDeleteRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserProfileDeleteArgs(
                userId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}