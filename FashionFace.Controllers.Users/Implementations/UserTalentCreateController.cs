using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Controllers.Users.Responses.Models;
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
public sealed class UserTalentCreateController(
    IUserTalentCreateFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task<UserTalentCreateResponse> Invoke(
        [FromBody] UserTalentCreateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserTalentCreateArgs(
                userId,
                request.TalentType,
                request.TalentDescription,
                request.PortfolioDescription
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserTalentCreateResponse(
                result.TalentId
            );

        return
            response;
    }
}