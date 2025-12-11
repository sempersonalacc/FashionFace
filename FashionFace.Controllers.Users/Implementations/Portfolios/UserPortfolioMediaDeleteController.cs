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
public sealed class UserPortfolioMediaDeleteController(
    IUserPortfolioMediaDeleteFacade facade
) : BaseUserController
{
    [ApiExplorerSettings(
        IgnoreApi = true
    )]
    [HttpDelete]
    public async Task Invoke(
        [FromBody] UserPortfolioMediaDeleteRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserPortfolioMediaDeleteArgs(
                userId,
                request.MediaId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}