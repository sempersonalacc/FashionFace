using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations;

[UserControllerGroup(
    "TalentLocation"
)]
[Route(
    "api/v1/user/talent-location"
)]
public sealed class UserTalentLocationDeleteController(
    IUserTalentLocationDeleteFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserTalentLocationDeleteRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserTalentLocationDeleteArgs(
                userId,
                request.TalentLocationId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}