using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.TalentLocations;
using FashionFace.Controllers.Users.Responses.Models.TalentLocations;
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
public sealed class UserTalentLocationCreateController(
    IUserTalentLocationCreateFacade facade
) : BaseUserController
{
    [HttpPost]
    public async Task<UserTalentLocationCreateResponse> Invoke(
        [FromBody] UserTalentLocationCreateRequest request
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
            new UserTalentLocationCreateArgs(
                userId,
                request.TalentId,
                request.LocationType,
                request.CityId,
                placeArgs
            );

        var result =
            await
                facade
                    .Execute(
                        facadeArgs
                    );

        var response =
            new UserTalentLocationCreateResponse(
                result.TalentLocationId
            );

        return
            response;
    }
}