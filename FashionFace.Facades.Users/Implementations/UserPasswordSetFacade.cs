using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Dependencies.Identity.Interfaces;
using FashionFace.Facades.Users.Args;
using FashionFace.Facades.Users.Interfaces;
using FashionFace.Repositories.Context.Models.IdentityEntities;

using static FashionFace.Common.Exceptions.Constants.ExceptionConstants;

namespace FashionFace.Facades.Users.Implementations;

public sealed class UserPasswordSetFacade(
    IUserManagerDecorator userManagerDecorator,
    IPasswordManagerDecorator passwordManagerDecorator,
    IExceptionDescriptor exceptionDescriptor
) : IUserPasswordSetFacade
{
    public async Task Execute(UserPasswordSetArgs args)
    {
        var (
            userId,
            oldPassword,
            newPassword
            ) = args;

        var user =
            await
                userManagerDecorator
                    .FindByIdAsync(
                        userId
                    );

        if (user is null)
        {
            throw exceptionDescriptor.NotFound<ApplicationUser>();
        }

        var validOldPassword =
            await
                passwordManagerDecorator
                    .CheckPasswordAsync(
                        user,
                        oldPassword
                    );

        if (!validOldPassword)
        {
            throw exceptionDescriptor.Exception(
                InvalidOldPassword
            );
        }

        var identityResult =
            await
                passwordManagerDecorator
                    .ChangePasswordAsync(
                        user,
                        oldPassword,
                        newPassword
                    );

        if (!identityResult.Succeeded)
        {
            throw exceptionDescriptor.IdentityErrorList(
                identityResult.Errors
            );
        }
    }
}