using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.TalentLocations;
using FashionFace.Facades.Users.Models.TalentLocations;

namespace FashionFace.Facades.Users.Interfaces.TalentLocations;

public interface IUserTalentLocationCreateFacade :
    IQueryFacade
    <
        UserTalentLocationCreateArgs,
        UserTalentLocationCreateResult
    >;