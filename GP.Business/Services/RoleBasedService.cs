using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GP.Business.Services
{
    public class RoleBasedService
    {
        public static async Task seedRolesAdminsAndUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Admin", "Customer" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!result.Succeeded)
                    {
                        Console.WriteLine($"❌ فشل في إنشاء الدور {roleName}");
                    }
                }
            }

            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                string adminPassword = "Admin@123";

                var createUser = await userManager.CreateAsync(user, adminPassword);
                if (createUser.Succeeded)
                {
                    var addRole = await userManager.AddToRoleAsync(user, "Admin");
                    if (!addRole.Succeeded)
                    {
                        Console.WriteLine($"❌ فشل في إضافة الدور Admin للمستخدم {adminEmail}");
                    }
                }
                else
                {
                    Console.WriteLine($"❌ فشل في إنشاء المستخدم {adminEmail}");
                }
            }
        }

    }
}