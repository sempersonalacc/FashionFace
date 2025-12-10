using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.TalentLocations;
using FashionFace.Facades.Users.Args.TalentLocations;
using FashionFace.Facades.Users.Interfaces.TalentLocations;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.TalentLocations;

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