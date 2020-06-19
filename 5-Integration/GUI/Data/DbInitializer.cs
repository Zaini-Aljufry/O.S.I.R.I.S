using GUI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";
            String adminId2 = "";

            string role1 = "Admin";
            string desc1 = "Administrator role are allowed access to all functions.";

            string role2 = "Manager";
            string desc2 = " Manager role are allowed access to most functions.";

            string role3 = "Engineer";
            string desc3 = "Engineer roles will defer for each department.";

            string password = "airforce1";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("323998") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "323998",
                    FirstName = " Sayyed Amir Zaini",
                    LastName = " Al-Jufry",
                    UniqueId = "323998",
                    Email = "amirzaini.s@digipen.edu",
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }
        }

        internal static object Initialize(object context, object userManager, object roleManager)
        {
            throw new NotImplementedException();
        }
    }
}
