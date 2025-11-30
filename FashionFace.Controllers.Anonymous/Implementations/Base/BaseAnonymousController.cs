using FashionFace.Controllers.Base.Implementations.Base;

using Microsoft.AspNetCore.Authorization;

namespace FashionFace.Controllers.Anonymous.Implementations.Base;

[AllowAnonymous]
public abstract class BaseAnonymousController :
    BaseController;