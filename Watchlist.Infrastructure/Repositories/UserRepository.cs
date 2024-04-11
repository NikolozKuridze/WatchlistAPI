using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist.Domain.Entities;
using Watchlist.Domain.Interfaces;

namespace Watchlist.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WatchListDbContext context) : base(context)
        {
        }
    }
}
