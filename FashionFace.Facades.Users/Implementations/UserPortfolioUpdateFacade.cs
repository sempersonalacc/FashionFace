using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Read.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserPortfolioUpdateFacade(
    IGenericReadRepository genericReadRepository,
    IUpdateRepository updateRepository,
    IExceptionDescriptor exceptionDescriptor
) : IUserPortfolioUpdateFacade
{
    public async Task Execute(
        UserPortfolioUpdateArgs args
    )
    {
        var (
            userId,
            portfolioId,
            description
            ) = args;

        var portfolioCollection =
            genericReadRepository.GetCollection<Portfolio>();

        var portfolio =
            await
                portfolioCollection
                    .FirstOrDefaultAsync(
                        entity =>
                            entity.Id == portfolioId
                            && entity
                                .Talent!
                                .Profile!
                                .ApplicationUserId
                            == userId
                    );

        if (portfolio is null)
        {
            throw exceptionDescriptor.NotFound<Portfolio>();
        }

        portfolio.Description =
            description;

        await
            updateRepository
                .UpdateAsync(
                    portfolio
                );
    }
}