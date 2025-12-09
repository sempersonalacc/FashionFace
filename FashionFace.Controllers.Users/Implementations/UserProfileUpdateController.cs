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
public sealed class UserProfileUpdateController(
    IUserProfileUpdateFacade facade
) : BaseUserController
{
    [HttpPut]
    public async Task Invoke(
        [FromBody] UserProfileUpdateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserProfileUpdateArgs(
                userId,
                request.Description,
                request.AgeCategoryType
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}