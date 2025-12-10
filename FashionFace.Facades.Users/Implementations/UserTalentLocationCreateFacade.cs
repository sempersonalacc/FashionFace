using System;
using System.Threading.Tasks;

using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Facades.Users.Models;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserTalentLocationCreateFacade(
    ICreateRepository createRepository
) : IUserTalentLocationCreateFacade
{
    public async Task<UserTalentLocationCreateResult> Execute(
        UserTalentLocationCreateArgs args
    )
    {
        var (
            _,
            talentId,
            locationType,
            cityId,
            place
            ) = args;

        var isPlaceType =
            locationType == LocationType.Place;

        var buildingName =
            isPlaceType
            && place?.BuildingName is not null
                ? place.BuildingName
                : string.Empty;

        var landmarkName =
            isPlaceType
            && place?.LandmarkName is not null
                ? place.LandmarkName
                : string.Empty;

        var street =
            isPlaceType
            && place?.Street is not null
                ? place.Street
                : string.Empty;

        var buildingId =
            Guid.NewGuid();

        var landmarkId =
            Guid.NewGuid();

        var building =
            new Building
            {
                Id = buildingId,
                Name = buildingName,
            };

        var landmark =
            new Landmark
            {
                Id = landmarkId,
                Name = landmarkName,
            };

        var placeId =
            Guid.NewGuid();

        var newPlace =
            new Place
            {
                Id = placeId,
                BuildingId = buildingId,
                LandmarkId = landmarkId,
                Street = street,
                Building = building,
                Landmark = landmark,
            };

        var talentLocation =
            new TalentLocation
            {
                Id =  Guid.NewGuid(),
                IsDeleted = false,
                TalentId =  talentId,
                LocationType =   locationType,
                CityId =  cityId,
                PlaceId =  placeId,
                Place = newPlace,
            };

        await
            createRepository
                .CreateAsync(
                    talentLocation
                );

        var result =
            new UserTalentLocationCreateResult(
                talentLocation.Id
            );

        return
            result;
    }
}