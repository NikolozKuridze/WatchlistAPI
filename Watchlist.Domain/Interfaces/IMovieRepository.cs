using Watchlist.Domain.Entities;

namespace Watchlist.Domain.Interfaces
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    {
        Task<IEnumerable<Movie>> SearchByTitleAsync(string title);
    }
}
