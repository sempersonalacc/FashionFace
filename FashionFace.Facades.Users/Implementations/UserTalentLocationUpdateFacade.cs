using System;
using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Repositories.Context.Enums;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserTalentLocationUpdateFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor,
    IUpdateRepository updateRepository,
    IDeleteRepository deleteRepository
) : IUserTalentLocationUpdateFacade
{
    public async Task Execute(
        UserTalentLocationUpdateArgs args
    )
    {
        var (
            userId,
            talentLocationId,
            locationType
            cityId,
            place
            ) = args;

        var talentLocationCollection =
            genericReadRepository.GetCollection<TalentLocation>();

        var talentLocation =
            await
                talentLocationCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == talentLocationId
                            && entity
                                .Talent!
                                .Profile!
                                .ApplicationUserId == userId
                    );

        if (talentLocation is null)
        {
            throw exceptionDescriptor.NotFound<TalentLocation>();
        }

        talentLocation.CityId =
            cityId;

        var oldPlaceId =
            talentLocation.PlaceId;

        if (locationType == LocationType.Place && place is not null)
        {
            var placeId =
                Guid.NewGuid();

            var newPlace =
                new Place
                {
                    Id = placeId,
                    Street = place.Street,

                };

            if (place.BuildingName is not null)
            {
                var newBuilding =
                    new Building
                    {
                        Id = Guid.NewGuid(),
                        PlaceId = placeId,
                        Name = place.BuildingName,
                    };

                newPlace.Building =
                    newBuilding;
            }

            if (place.LandmarkName is not null)
            {
                var newLandmark =
                    new Landmark
                    {
                        Id = Guid.NewGuid(),
                        PlaceId = placeId,
                        Name = place.LandmarkName,
                    };

                newPlace.Landmark =
                    newLandmark;
            }

            talentLocation.Place =
                newPlace;
        }

        await
            updateRepository
                .UpdateAsync(
                    talentLocation
                );


        var placeCollection =
            genericReadRepository.GetCollection<Place>();

        var oldPlace =
            await
                placeCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == oldPlaceId
                    );

        await
            deleteRepository
                .DeleteAsync(
                    oldPlace!
                );
    }
}