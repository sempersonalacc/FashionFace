using System;
using System.Threading.Tasks;

using FashionFace.Common.Exceptions.Interfaces;
using FashionFace.Dependencies.Identity.Interfaces;
using FashionFace.Facades.Anonymous.Args;
using FashionFace.Facades.Anonymous.Interfaces;
using FashionFace.Repositories.Context.Models;
using FashionFace.Repositories.Context.Models.IdentityEntities;
using FashionFace.Repositories.Interfaces;
using FashionFace.Repositories.Transactions.Interfaces;

namespace FashionFace.Facades.Anonymous.Implementations;

public sealed class RegisterFacade(
    IUserManagerDecorator userManagerDecorator,
    IExceptionDescriptor exceptionDescriptor,
    ICreateRepository createRepository,
    ITransactionManager  transactionManager
) : IRegisterFacade
{
    public async Task Execute(
        RegisterArgs args
    )
    {
        var (
            email,
            password
            ) = args;

        var identityFindByEmailResult =
            await
                userManagerDecorator
                    .FindByEmailAsync(
                        email
                    );

        if (identityFindByEmailResult is not null)
        {
            throw exceptionDescriptor.Exists<ApplicationUser>();
        }

        using var transaction =
            await
                transactionManager.BeginTransaction();

        var applicationUser =
            new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

        var identityCreateResult =
            await
                userManagerDecorator
                    .CreateAsync(
                        applicationUser,
                        password
                    );

        if (!identityCreateResult.Succeeded)
        {
            throw exceptionDescriptor.IdentityErrorList(
                identityCreateResult.Errors
            );
        }

        var profile =
            new Profile
            {
                Id = Guid.NewGuid(),
                ApplicationUserId = applicationUser.Id,
            };

        await
            createRepository
                .CreateAsync(
                    profile
                );

        await
            transaction.CommitAsync();
    }
}