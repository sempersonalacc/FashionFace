using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args.TalentLocations;
using FashionFace.Facades.Users.Interfaces.TalentLocations;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations.TalentLocations;

public sealed class UserTalentLocationDeleteFacade(
    IGenericReadRepository genericReadRepository,
    IUpdateRepository updateRepository,
    IExceptionDescriptor exceptionDescriptor
) : IUserTalentLocationDeleteFacade
{
    public async Task Execute(
        UserTalentLocationDeleteArgs args
    )
    {
        var (
            userId,
            talentLocationId
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
                                .ProfileTalent!
                                .Profile!
                                .ApplicationUserId == userId
                    );

        if (talentLocation is null)
        {
            throw exceptionDescriptor.NotFound<TalentLocation>();
        }

        talentLocation.IsDeleted = true;

        await
            updateRepository
                .UpdateAsync(
                    talentLocation
                );
    }
}