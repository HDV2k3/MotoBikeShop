using Microsoft.AspNetCore.Identity;
using System.Data;

namespace MotoBikeShop.Models
{
    public class InitUser
    {
        public static async Task Initialize(IServiceProvider services, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { SD.Role_Admin};
            var users = new[]
            {
            new { Email = "admin@dksh.com", Role = SD.Role_Admin, FirstName = "Admin", LastName = "User", Password = "Password123!" },

        };

            // Create roles if not already created
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create users if not already created
            foreach (var userInfo in users)
            {
                var user = await userManager.FindByEmailAsync(userInfo.Email);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = userInfo.Email,
                        Email = userInfo.Email,
                        FullName = userInfo.FirstName + userInfo.LastName,

                    };

                    var result = await userManager.CreateAsync(user, userInfo.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, userInfo.Role);
                    }
                }
            }
        }
    }
}
