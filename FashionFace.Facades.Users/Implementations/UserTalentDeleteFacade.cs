using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserTalentDeleteFacade(
    IGenericReadRepository genericReadRepository,
    IUpdateRepository updateRepository,
    IExceptionDescriptor exceptionDescriptor
) : IUserTalentDeleteFacade
{
    public async Task Execute(
        UserTalentDeleteArgs args
    )
    {
        var (
            userId,
            talentId
            ) = args;

        var talentCollection =
            genericReadRepository.GetCollection<Talent>();

        var talent =
            await
                talentCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == talentId
                            && entity
                                .Profile!
                                .ApplicationUserId == userId
                    );

        if (talent is null)
        {
            throw exceptionDescriptor.NotFound<Talent>();
        }

        talent.IsDeleted = true;

        await
            updateRepository
                .UpdateAsync(
                    talent
                );
    }
}