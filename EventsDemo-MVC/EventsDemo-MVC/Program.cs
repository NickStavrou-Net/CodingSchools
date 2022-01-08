using EventsDemo_MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo_MVC
{
   public class Program
   {
      public static void Main(string[] args)
      {
         // CreateHostBuilder(args).Build().Run();

         var host = CreateHostBuilder(args).Build();

         // Database seeding
         using (var scope = host.Services.CreateScope())
         {
            var services = scope.ServiceProvider;

            // requires using Microsoft.Extensions.Configuration;
            var config = host.Services.GetRequiredService<IConfiguration>();
            // Set password with the Secret Manager tool.
            // dotnet user-secrets set SeedUserPW <pw>

            var context = services.GetRequiredService<Data.ApplicationDbContext>();
            context.Database.Migrate();
            SeedData.Initialize(services).Wait();

         }

         host.Run();

      }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                 webBuilder.UseStartup<Startup>();
              });
   }
}
