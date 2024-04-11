using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WatchListDbContext>
    {
        public WatchListDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WatchListDbContext>();
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=WatchlistDb;Trusted_Connection=True;";  
            builder.UseSqlServer(connectionString);

            return new WatchListDbContext(builder.Options);
        }
    }
}
