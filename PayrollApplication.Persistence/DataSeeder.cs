using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.Persistence
{
    public class DataSeeder
    {
        public static async Task  SeedUsersAndRolesAsync(UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        
        {
            string[] roles = { "Admin", "Manager", "Staff" };

            foreach(var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    IdentityResult result = await roleManager.CreateAsync( new IdentityRole(role));
                }
            }

            //Creates admin user
            if (userManager.FindByEmailAsync("admin@localhost.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"
                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            //manager
            if (userManager.FindByEmailAsync("manager@localhost.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "manager@localhost.com",
                    Email = "manager@localhost.com"
                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }
            // staff
            if (userManager.FindByEmailAsync("staff@localhost.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "staff@localhost.com",
                    Email = "staff@localhost.com"
                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();
                }
            }
            //no role
            if (userManager.FindByEmailAsync("simple@localhost.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "simple@localhost.com",
                    Email = "simple@localhost.com"
                };

                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;

               
            }
        }
    }
}
