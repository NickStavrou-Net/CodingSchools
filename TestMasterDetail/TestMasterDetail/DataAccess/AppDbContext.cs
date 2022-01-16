using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMasterDetail.DataAccess
{
   public class AppDbContext : DbContext
   {
      public DbSet<Team> Teams { get; set; }
      public DbSet<TeamMember> TeamMembers { get; set; }
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {

      }
   }
}
