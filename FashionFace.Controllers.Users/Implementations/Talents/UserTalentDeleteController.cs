using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.Talents;
using FashionFace.Facades.Users.Args.Talents;
using FashionFace.Facades.Users.Interfaces.Talents;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.Talents;

[UserControllerGroup(
    "Talent"
)]
[Route(
    "api/v1/user/talent"
)]
public sealed class UserTalentDeleteController(
    IUserTalentDeleteFacade facade
) : BaseUserController
{
    [HttpDelete]
    public async Task Invoke(
        [FromBody] UserTalentDeleteRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserTalentDeleteArgs(
                userId,
                request.TalentId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}