using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist.Domain.Entities;
using Watchlist.Domain.Interfaces;

namespace Watchlist.Infrastructure.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        #region Private Members

        private readonly WatchListDbContext _context;

        #endregion

        #region Constructors 
        public MovieRepository(WatchListDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Movie>> SearchByTitleAsync(string title)
        {
            return await _context.movies!.Where(f => f.Title!.Contains(title)).ToListAsync();
        }
        #endregion
    }
}
