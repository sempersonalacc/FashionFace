using System.Threading.Tasks;

using FashionFace.Controllers.Base.Attributes.Groups;
using FashionFace.Controllers.Users.Implementations.Base;
using FashionFace.Controllers.Users.Requests.Models.AppearanceTraits;
using FashionFace.Facades.Users.Args.AppearanceTraits;
using FashionFace.Facades.Users.Interfaces.AppearanceTraits;

using Microsoft.AspNetCore.Mvc;

namespace FashionFace.Controllers.Users.Implementations.AppearanceTraits;

[UserControllerGroup(
    "AppearanceTraits"
)]
[Route(
    "api/v1/user/appearance-traits"
)]
public sealed class UserAppearanceTraitsUpdateController(
    IUserAppearanceTraitsUpdateFacade facade
) : BaseUserController
{
    [HttpPut]
    public async Task Invoke(
        [FromBody] UserAppearanceTraitsUpdateRequest request
    )
    {
        var userId =
            GetUserId();

        var facadeArgs =
            new UserAppearanceTraitsUpdateArgs(
                userId,
                request.SexType,
                request.FaceType,
                request.HairColorType,
                request.HairType,
                request.HairLengthType,
                request.BodyType,
                request.SkinToneType,
                request.EyeShapeType,
                request.EyeColorType,
                request.NoseType,
                request.JawType,
                request.Height,
                request.ShoeSize
            );

        await
            facade
                .Execute(
                    facadeArgs
                );
    }
}