using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist.Domain.Entities;

namespace Watchlist.Infrastructure
{
    public class WatchListDbContext : DbContext
    {
        #region Constructors
        public WatchListDbContext(DbContextOptions<WatchListDbContext> options) : base(options)
        {
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "The Batman", Rating = 9.3, Description = "A masked vigilante battles crime and corruption in Gotham City while grappling with his own inner demons." },
                new Movie { Id = 2, Title = "ცისფერი მთები", Rating = 10, Description = "Description 2" },
                new Movie { Id = 3, Title = "დათა თუთაშხია", Rating = 9.0, Description = "Description 3" },
                new Movie { Id = 4, Title = "უძინართა მზე", Rating = 8.9, Description = "Description 4" },
                new Movie { Id = 5, Title = "The GodFather", Rating = 8.9, Description = "Description 5" }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1 },
                new User { Id = 2 },
                new User { Id = 3 },
                new User { Id = 4 },
                new User { Id = 5 }
                );
        }
        #endregion

        #region Tables 

        public DbSet<Movie>? movies { get; set; }
        public DbSet<WatchlistItem>? WatchlistItems { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion


    }

}
