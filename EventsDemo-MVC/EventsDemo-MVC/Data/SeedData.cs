using EventsDemo_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -udl -outDir Pages\Contacts --referenceScriptLibraries

namespace EventsDemo_MVC.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, "123456", "admin@contoso.com");
                await EnsureRole(serviceProvider, adminID, "Administrator");  // Seeds an Administrator and User role

                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
                if (roleManager.FindByNameAsync("Customer").Result != null) {
                    await roleManager.CreateAsync(new IdentityRole("Customer"));
                }

                SeedDB(context);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<MyUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new MyUser { UserName = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            // User role
            if (!await roleManager.RoleExistsAsync("User"))
            {
               IR = await roleManager.CreateAsync(new IdentityRole("User"));
            }

            // Administrator role
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<MyUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(ApplicationDbContext context)
        {
            context.Add<Event>(new Event { Name = "Event 1" });
            context.Add<Event>(new Event { Name = "Event 2" });
            context.SaveChanges();
        }

    }
}