using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserTalentUpdateFacade(
    IGenericReadRepository genericReadRepository,
    IExceptionDescriptor exceptionDescriptor,
    IUpdateRepository updateRepository
) : IUserTalentUpdateFacade
{
    public async Task Execute(
        UserTalentUpdateArgs args
    )
    {
        var (
            userId,
            talentId,
            description,
            talentType
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

        if (description is not null)
        {
            talent.Description =
                description;
        }

        if (talentType is not null)
        {
            talent.Type =
                talentType.Value;
        }

        await
            updateRepository
                .UpdateAsync(
                    talent
                );
    }
}