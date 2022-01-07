using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp1.Models;

namespace TestApp1.Data
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
