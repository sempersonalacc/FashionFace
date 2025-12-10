using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.Portfolios;
using FashionFace.Facades.Users.Models.Portfolios;

namespace FashionFace.Facades.Users.Interfaces.Portfolios;

public interface IUserPortfolioTagListFacade :
    IQueryFacade
    <
        UserPortfolioTagListArgs,
        ListResult<UserTagListItemResult>>;