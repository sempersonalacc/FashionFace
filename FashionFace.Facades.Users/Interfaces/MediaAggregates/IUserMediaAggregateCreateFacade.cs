using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.MediaAggregates;
using FashionFace.Facades.Users.Models.MediaAggregates;

namespace FashionFace.Facades.Users.Interfaces.MediaAggregates;

public interface IUserMediaAggregateCreateFacade :
    IQueryFacade
    <
        UserMediaAggregateCreateArgs,
        UserMediaAggregateCreateResult
    >;