using EventsDemo_MVC.Data;
using EventsDemo_MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo_MVC
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));
         services.AddDatabaseDeveloperPageExceptionFilter();

         services.AddDefaultIdentity<MyUser>(options => options.SignIn.RequireConfirmedAccount = false)
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>();
         services.AddControllersWithViews();

         services.Configure<IdentityOptions>(opt =>
         {
            // Setting-up the password policy
            opt.Password.RequireDigit = false;
            opt.Password.RequiredLength = 6;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = false;
            opt.SignIn.RequireConfirmedEmail = false;
         });

         services.AddAuthentication().AddGoogle(googleOptions =>
            {
               googleOptions.ClientId = "982678338186-csn0m8nhdmuebdtdmqqaa6gbi4b3bbr2.apps.googleusercontent.com";
               googleOptions.ClientSecret = "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";
            }
         );

         

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
         });
      }
   }
}
