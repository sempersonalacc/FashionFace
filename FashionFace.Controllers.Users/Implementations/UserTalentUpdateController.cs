using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations;

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
                request.Description,
                request.TalentType
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}