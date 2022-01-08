using EventsDemo_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDemo_MVC.Data
{
   public class ApplicationDbContext : IdentityDbContext<MyUser>
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }

      public DbSet<Event> Events { get; set; }
   }
}
