using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.TalentLocations;
using FashionFace.Facades.Users.Models.TalentLocations;

namespace FashionFace.Facades.Users.Interfaces.TalentLocations;

public interface IUserTalentLocationListFacade :
    IQueryFacade
    <
        UserTalentLocationListArgs,
        ListResult<UserTalentLocationListItemResult>>;