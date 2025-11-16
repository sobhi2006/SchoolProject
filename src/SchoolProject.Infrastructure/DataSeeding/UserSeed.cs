using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities.Identity;

namespace SchoolProject.Infrastructure.DataSeeding;

public static class UserSeed
{
    public static async Task SeedAsync(UserManager<User> userManager)
    {
        var ExistAnyUser = await userManager.Users.AnyAsync();
        if(!ExistAnyUser)
        {
            var DefaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = "u@gmail.com",
                Address = "Aleppo",
                Country = "Syria",
                FullName = "Sobhi Hazouri",
                PhoneNumber = "1234567890",
                UserName = "Admin",
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(DefaultUser, "Admin1234@");
            System.Console.WriteLine(result.Succeeded? "\n\n\n\n\n\n\n\n\n Success" : 
            "\n\n\n\n\n\n\n\nFailed" + string.Join("\n",result.Errors.Select(r => r.Description)));
            await userManager.AddToRoleAsync(DefaultUser, "Admin");
        }
    }
}