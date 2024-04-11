using System.Linq.Expressions;
using Watchlist.Domain.Entities;

namespace Watchlist.Domain.Interfaces
{
    public interface IWatchlistRepository
    {
        Task<WatchlistItem> AddToWatchlistAsync(int userId, int movieId);
        Task<IEnumerable<WatchlistItem>> GetWatchlistForUserAsync(int userId);
        Task MarkMovieAsWatchedAsync(int userId, int movieId);  
    }
}
