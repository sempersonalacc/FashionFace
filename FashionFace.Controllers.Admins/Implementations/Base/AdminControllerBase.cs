using FashionFace.Controllers.Base.Attributes.Authorization;
using FashionFace.Controllers.Base.Implementations.Base;

namespace FashionFace.Controllers.Admins.Implementations.Base;

[AuthorizeAdmin]
public abstract class AdminControllerBase : AuthorizedControllerBase;