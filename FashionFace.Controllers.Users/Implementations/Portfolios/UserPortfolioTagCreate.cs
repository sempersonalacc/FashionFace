using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.Portfolios;
using FashionFace.Facades.Users.Args.Portfolios;
using FashionFace.Facades.Users.Interfaces.Portfolios;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.Portfolios;

[UserControllerGroup(
    "Portfolio"
)]
[Route(
    "api/v1/user/portfolio/tag"
)]
public sealed class UserPortfolioTagCreateController(
    IUserPortfolioTagCreateFacade facade
) : UserControllerBase
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