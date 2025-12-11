using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.MediaEntity;
using FashionFace.Facades.Users.Models.MediaEntity;

namespace FashionFace.Facades.Users.Interfaces.MediaEntity;

public interface IUserMediaCreateFacade :
    IQueryFacade
    <
        UserMediaCreateArgs,
        UserMediaCreateResult
    >;