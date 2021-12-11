using Microsoft.EntityFrameworkCore;
using MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovies.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(g => g.Genre)
                .HasConversion<string>()
                .HasMaxLength(50);
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
