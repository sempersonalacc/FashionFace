using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.AppearanceTraits;
using FashionFace.Facades.Users.Models.AppearanceTraits;

namespace FashionFace.Facades.Users.Interfaces.AppearanceTraits;

public interface IUserMaleTraitsFacade :
    IQueryFacade
    <
        UserMaleTraitsArgs,
        UserMaleTraitsResult
    >;