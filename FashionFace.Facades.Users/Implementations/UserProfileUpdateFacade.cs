using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserProfileUpdateFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor,
    IUpdateRepository updateRepository
) : IUserProfileUpdateFacade
{
    public async Task Execute(
        UserProfileUpdateArgs args
    )
    {
        var (
            userId,
            description,
            ageCategoryType
            ) = args;

        var profileCollection =
            genericReadRepository.GetCollection<Profile>();

        var profile =
            await
                profileCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            entity.ApplicationUserId == userId
                    );

        if (profile is null)
        {
            throw exceptionDescriptor.NotFound<Profile>();
        }

        if (description is not null)
        {
            profile.Description =
                description;
        }

        if (ageCategoryType is not null)
        {
            profile.AgeCategoryType =
                ageCategoryType.Value;
        }

        await
            updateRepository
                .UpdateAsync(
                    profile
                );
    }
}