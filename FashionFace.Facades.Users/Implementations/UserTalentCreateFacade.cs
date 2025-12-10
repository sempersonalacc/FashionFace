using System;
using System.Threading.Tasks;

using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Facades.Users.Models;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserTalentCreateFacade(
    IGenericReadRepository genericReadRepository,
    ICreateRepository createRepository
) : IUserTalentCreateFacade
{
    public async Task<UserTalentCreateResult> Execute(
        UserTalentCreateArgs args
    )
    {
        var (
            userId,
            talentType,
            talentDescription,
            portfolioDescription
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

        var talentId =
            Guid.NewGuid();

        var portfolio =
            new Portfolio
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                TalentId = talentId,
                Description = portfolioDescription,
            };

        var talent =
            new Talent
            {
                Id = talentId,
                IsDeleted = false,
                ProfileId = profile!.Id,
                TalentType = talentType,
                Description = talentDescription,
                Portfolio = portfolio,
            };

        await
            createRepository
                .CreateAsync(
                    talent
                );

        var result =
            new UserTalentCreateResult(
                talent.Id
            );

        return
            result;
    }
}