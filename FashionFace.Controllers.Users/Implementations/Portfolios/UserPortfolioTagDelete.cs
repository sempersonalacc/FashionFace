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
public sealed class UserPortfolioTagDeleteController(
    IUserPortfolioTagDeleteFacade facade
) : UserControllerBase
{
    [HttpDelete]
    public async Task Invoke(
        [FromBody] UserPortfolioTagDeleteRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPortfolioTagDeleteArgs(
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