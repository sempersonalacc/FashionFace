using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations;

[UserControllerGroup(
    "Portfolio"
)]
[Route(
    "api/v1/user/portfolio"
)]
public sealed class UserPortfolioUpdateController(
    IUserPortfolioUpdateFacade facade
) : BaseUserController
{
    [HttpPut]
    public async Task Invoke(
        [FromBody] UserPortfolioUpdateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPortfolioUpdateArgs(
                userId,
                request.PortfolioId,
                request.Description
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}