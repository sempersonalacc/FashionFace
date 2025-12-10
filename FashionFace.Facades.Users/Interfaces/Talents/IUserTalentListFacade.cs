using FashionFace.Facades.Base.Interfaces;
using FashionFace.Facades.Base.Models;
using FashionFace.Facades.Users.Args.Talents;
using FashionFace.Facades.Users.Models.Talents;

namespace FashionFace.Facades.Users.Interfaces.Talents;

public interface IUserTalentListFacade :
    IQueryFacade
    <
        UserTalentListArgs,
        ListResult<UserTalentListItemResult>>;