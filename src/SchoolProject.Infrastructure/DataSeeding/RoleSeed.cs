using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Infrastructure.DataSeeding;

public static class RoleSeed
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        var ExistAnyUser = await roleManager.Roles.AnyAsync();
        if(!ExistAnyUser)
        {
            var DefaultIdentityRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin"
            };
            await roleManager.CreateAsync(DefaultIdentityRole);
        }
    }
}