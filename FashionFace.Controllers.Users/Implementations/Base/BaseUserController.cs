using FashionFace.Controllers.Base.Attributes.Authorization;
using FashionFace.Controllers.Base.Implementations.Base;

namespace FashionFace.Controllers.Users.Implementations.Base;

[AuthorizeUser]
public abstract class BaseUserController : BaseAuthorizeController;