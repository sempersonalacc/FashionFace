using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.Portfolios;
using FashionFace.Facades.Users.Models.Portfolios;

namespace FashionFace.Facades.Users.Interfaces.Portfolios;

public interface IUserPortfolioFacade :
    IQueryFacade
    <
        UserPortfolioArgs,
        UserPortfolioResult
    >;