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
    "api/v1/user/portfolio/tag"
)]
public sealed class UserPortfolioTagCreateController(
    IUserPortfolioTagCreateFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserPortfolioTagCreateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPortfolioTagCreateArgs(
                userId,
                request.TagId,
                request.PortfolioId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}