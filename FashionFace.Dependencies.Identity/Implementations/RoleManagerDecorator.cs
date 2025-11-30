using System.Threading.Tasks;

using FashionFace.Dependencies.Identity.Interfaces;
using FashionFace.Repositories.Context.Models.IdentityEntities;

using Microsoft.AspNetCore.Identity;

namespace FashionFace.Dependencies.Identity.Implementations;

public sealed class RoleManagerDecorator(
    UserManager<ApplicationUser> userManager
) : IRoleManagerDecorator
{
    public async Task<IdentityResult> AddToRoleAsync(
        ApplicationUser user,
        string role
    ) =>
        await userManager.AddToRoleAsync(
            user,
            role
        );
}