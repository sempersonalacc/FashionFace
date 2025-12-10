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
public sealed class UserPortfolioTagDeleteController(
    IUserPortfolioTagDeleteFacade facade
) : BaseUserController
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
                request.TagId
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}