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
public sealed class UserTalentUpdateController(
    IUserTalentUpdateFacade facade
) : BaseUserController
{
    [HttpPut]
    public async Task Invoke(
        [FromBody] UserTalentUpdateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserTalentUpdateArgs(
                userId,
                request.TalentId,
                request.Description
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}