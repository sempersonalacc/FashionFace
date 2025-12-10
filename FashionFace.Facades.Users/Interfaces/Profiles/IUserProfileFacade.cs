using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.Profiles;
using FashionFace.Facades.Users.Models.Profiles;

namespace FashionFace.Facades.Users.Interfaces.Profiles;

public interface IUserProfileFacade :
    IQueryFacade
    <
        UserProfileArgs,
        UserProfileResult
    >;