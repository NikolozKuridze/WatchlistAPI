using MediatR;
using Watchlist.Domain.Entities; 

namespace Watchlist.API.Requests.Queries
{
    public record GetWatchlistQuery(int UserId) : IRequest<IEnumerable<WatchlistItem>>;
}
