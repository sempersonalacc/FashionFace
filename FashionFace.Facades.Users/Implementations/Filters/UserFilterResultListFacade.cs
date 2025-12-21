using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Common.Extensions.Implementations;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.Filters;
using FashionFace.Facades.Users.Interfaces.Filters;
using FashionFace.Facades.Users.Models.Portfolios;
using FashionFace.Repositories.Context.Models.Filters;
using FashionFace.Repositories.Context.Models.MediaEntities;
using FashionFace.Repositories.Context.Models.Talents;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.Filters;

public sealed class UserFilterResultListFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor
) : IUserFilterResultListFacade
{
    public async Task<ListResult<UserMediaListItemResult>> Execute(
        UserFilterResultListArgs args
    )
    {
        var (
            userId,
            filterId,
            offset,
            count
            ) = args;

        var filterCollection =
            genericReadRepository.GetCollection<Filter>();

        var filter =
            await
                filterCollection
                    .Include(entity => entity.FilterCriteria)
                    .ThenInclude(entity => entity.AppearanceTraits)
                    .ThenInclude(entity => entity.Height)
                    .ThenInclude(entity => entity.FilterRangeValue)

                    .Include(entity => entity.FilterCriteria)
                    .ThenInclude(entity => entity.AppearanceTraits)
                    .ThenInclude(entity => entity.ShoeSize)
                    .ThenInclude(entity => entity.FilterRangeValue)

                    .Include(entity => entity.FilterCriteria)
                    .ThenInclude(entity => entity.Location)
                    .ThenInclude(entity => entity.Place)

                    .Include(entity => entity.FilterCriteria)
                    .ThenInclude(entity => entity.DimensionCollection)

                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == filterId
                            && entity.ApplicationUserId == userId
                    );

        if (filter is null)
        {
            throw exceptionDescriptor.NotFound<Filter>();
        }

        var filterCriteriaDimensionList =
            filter
                .FilterCriteria!
                .DimensionCollection
                .Select(
                    entity => entity.DimensionValueId
                )
                .Distinct()
                .ToList();

        if (filterCriteriaDimensionList.IsEmpty())
        {
            throw exceptionDescriptor.NotFound<FilterCriteriaDimension>();
        }

        var talentFilterDimensionCollection =
            genericReadRepository.GetCollection<TalentDimensionValue>();

        var talentFilterDimensionQuery =
            talentFilterDimensionCollection
            .Where(
                entity =>
                    filterCriteriaDimensionList
                        .Any(
                            dimensionValueId =>
                                dimensionValueId == entity.DimensionValueId
                        )
            )
            .GroupBy(
                entity => entity.TalentId
            )
            .Where(
                entity =>
                    entity.Count() == filterCriteriaDimensionList.Count
            )
            .Select(
                entity => entity.Key
            );

        var totalCount =
            await
                talentFilterDimensionQuery.CountAsync();

        var talentCollection =
            genericReadRepository.GetCollection<Talent>();

        var queryable =
            talentCollection.AsQueryable();

        var criteriaAppearanceTraits =
            filter
                .FilterCriteria
                .AppearanceTraits;

        if (criteriaAppearanceTraits is not null)
        {
            var height =
                criteriaAppearanceTraits
                    .Height?
                    .FilterRangeValue;

            if (height is not null)
            {
                queryable =
                    queryable
                        .Where(
                            entity =>
                                entity.ProfileTalent!.Profile!.AppearanceTraits!.Height >= height.Min
                                && entity.ProfileTalent.Profile.AppearanceTraits.Height <= height.Max
                        );
            }

            var shoeSize =
                criteriaAppearanceTraits
                    .ShoeSize?
                    .FilterRangeValue;

            if (shoeSize is not null)
            {
                queryable =
                    queryable
                        .Where(
                            entity =>
                                entity.ProfileTalent!.Profile!.AppearanceTraits!.ShoeSize >= shoeSize.Min
                                && entity.ProfileTalent.Profile.AppearanceTraits.ShoeSize <= shoeSize.Max
                        );
            }
        }

        var criteriaLocation =
            filter
                .FilterCriteria
                .Location;

        if (criteriaLocation is not null)
        {
            queryable =
                queryable
                    .Where(
                        entity =>
                            entity
                                .LocationCollection
                                .Any(
                                    location =>
                                        location.CityId == criteriaLocation.CityId
                                )
                    );
        }

        var criteriaTagList =
            filter
                .FilterCriteria
                .TagCollection;

        if (criteriaTagList.IsNotEmpty())
        {
            queryable =
                queryable
                    .Where(
                        entity =>
                            criteriaTagList.All(
                                filterTag =>
                                    entity
                                        .Portfolio!
                                        .PortfolioTagCollection
                                        .Any(
                                            portfolioTag =>
                                                portfolioTag.Id == filterTag.Id
                                        )
                            )

                    );
        }

        queryable =
            queryable
                .Where(
                    entity =>
                        talentFilterDimensionQuery
                            .Contains(
                                entity.Id
                            )
                );

        var talentIdMediaAggregateIdList =
            queryable
                .OrderBy(
                    entity => entity
                )
                .Skip(
                    offset
                )
                .Take(
                    count
                )
                .Select(
                    entity => new
                    {
                        TalentId =
                            entity.Id,
                        TalantMediaAggregate =
                            entity.TalentMediaAggregate,
                        ProfileMediaAggregate =
                            entity
                                .ProfileTalent!
                                .Profile!
                                .ProfileMediaAggregate,
                    }
                )
                .Select(
                    entity =>
                        new
                        {
                            TalentId = entity.TalentId,
                            MediaAggregateId =
                                entity.TalantMediaAggregate != null
                                    ? entity.TalantMediaAggregate.MediaAggregateId
                                    : entity.ProfileMediaAggregate != null
                                        ? entity.ProfileMediaAggregate.MediaAggregateId
                                        : Guid.Empty,
                        }
                );

        var mediaAggregateCollection =
            genericReadRepository.GetCollection<MediaAggregate>();

        var mediaAggregateList =
            await
                mediaAggregateCollection
                    .Include(
                        entity => entity.PreviewMedia
                    )
                    .ThenInclude(
                        entity => entity.OptimizedFile
                    )
                    .Where(
                        entity =>
                            talentIdMediaAggregateIdList
                                .Any(
                                    model =>
                                        entity.Id == model.MediaAggregateId
                                )
                    )
                    .ToListAsync();

        var talentFilterDimensionList =
            new List<UserMediaListItemResult>();

        foreach (var model in talentIdMediaAggregateIdList)
        {
            var relativePath = string.Empty;
            var description = string.Empty;

            if (model.MediaAggregateId != Guid.Empty)
            {
                var mediaAggregate =
                    mediaAggregateList
                        .FirstOrDefault(
                            entity =>
                                entity.Id == model.MediaAggregateId
                        );

                relativePath =
                    mediaAggregate?
                        .PreviewMedia?
                        .OptimizedFile?
                        .RelativePath
                    ?? string.Empty;

                description =
                    mediaAggregate?.Description
                    ?? string.Empty;
            }


            var listItem =
                new UserMediaListItemResult(
                    model.TalentId,
                    offset,
                    description,
                    relativePath
                );

            talentFilterDimensionList
                .Add(
                    listItem
                );
        }

        var result =
            new ListResult<UserMediaListItemResult>(
                totalCount,
                talentFilterDimensionList
            );

        return
            result;
    }
}