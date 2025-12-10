using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.TalentLocations;
using FashionFace.Facades.Users.Args.TalentLocations;
using FashionFace.Facades.Users.Interfaces.TalentLocations;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.TalentLocations;

[UserControllerGroup(
    "TalentLocation"
)]
[Route(
    "api/v1/user/talent-location"
)]
public sealed class UserTalentLocationUpdateController(
    IUserTalentLocationUpdateFacade facade
) : BaseUserController
{
    [ApiExplorerSettings(
        IgnoreApi = true
    )]
    [HttpPut]
    public async Task Invoke(
        [FromBody] UserTalentLocationUpdateRequest request
    )
    {
        var userId =
            GetUserId();

        var requestPlace =
            request.Place;

        var placeArgs =
            requestPlace is null
                ? null
                : new PlaceArgs(
                    requestPlace.Street,
                    requestPlace.BuildingName,
                    requestPlace.LandmarkName
                );

        var facadeArgs =
            new UserTalentLocationUpdateArgs(
                userId,
                request.TalentLocationId,
                request.LocationType,
                request.CityId,
                placeArgs
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}