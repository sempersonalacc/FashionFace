using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Users.Args.Talents;
using FashionFace.Facades.Users.Models.Talents;

namespace FashionFace.Facades.Users.Interfaces.Talents;

public interface IUserTalentCreateFacade :
    IQueryFacade
    <
        UserTalentCreateArgs,
        UserTalentCreateResult
    >;