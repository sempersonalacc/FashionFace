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
    "api/v1/user/portfolio/media"
)]
public sealed class UserPortfolioMediaCreateController(
    IUserPortfolioMediaCreateFacade facade
) : BaseUserController
{
    [ApiExplorerSettings(
        IgnoreApi = true
    )]
    [HttpPost]
    public async Task Invoke(
        [FromBody] UserPortfolioMediaCreateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPortfolioMediaCreateArgs(
                userId,
                request.MediaId,
                request.PortfolioId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}