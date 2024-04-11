using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Watchlist.Domain.Entities;
using Watchlist.Domain.Interfaces;

namespace Watchlist.Infrastructure.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        #region Private Members

        private readonly WatchListDbContext _context;
        #endregion

        #region Constructors
        public WatchlistRepository(WatchListDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Private Methods 

        private async Task<bool> WatchlistIsExist(int userId, int movieId)
        {
            var entity = await _context.WatchlistItems!.FirstOrDefaultAsync(x => x.UserId == userId && x.movieId == movieId);
            return entity != null ? true : false;
        }

        #endregion

        #region Methods

        public async Task<WatchlistItem> AddToWatchlistAsync(int userId, int movieId)
        {
            var watchlistItem = new WatchlistItem { UserId = userId, movieId = movieId };

            if (await WatchlistIsExist(userId, movieId))
            {
                return watchlistItem;
            }
            else
            {
                _context.WatchlistItems!.Add(watchlistItem);
                await _context.SaveChangesAsync();
                return watchlistItem;
            }

        }

        public async Task<IEnumerable<WatchlistItem>> GetWatchlistForUserAsync(int userId)
        {
            return await _context.WatchlistItems!.Where(wi => wi.UserId == userId).Include(wi => wi.movie).ToListAsync();
        }

        public async Task MarkMovieAsWatchedAsync(int userId, int movieId)
        {
            var watchlistItem = await _context.WatchlistItems!.Include(wi => wi.movie).FirstOrDefaultAsync(wi => wi.UserId == userId && wi.movieId == movieId);
            if (watchlistItem != null)
            {
                watchlistItem.IsWatched = true;
                await _context.SaveChangesAsync();
            }
        }
        #endregion

    }
}
