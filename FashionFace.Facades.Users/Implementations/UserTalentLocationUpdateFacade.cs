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
            locationType,
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

        if (locationType == LocationType.Place)
        {
            var buildingId =
                Guid.NewGuid();

            var landmarkId =
                Guid.NewGuid();

            var building =
                new Building
                {
                    Id = buildingId,
                    Name = place?.BuildingName ??  string.Empty,
                };

            var landmark =
                new Landmark
                {
                    Id = landmarkId,
                    Name = place?.LandmarkName ??  string.Empty,
                };

            talentLocation.Place =
                new()
                {
                    Id = Guid.NewGuid(),
                    BuildingId = buildingId,
                    LandmarkId = landmarkId,
                    Street = place?.Street ?? string.Empty,
                    Building = building,
                    Landmark = landmark,

                };
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