using MediatR;
using Watchlist.Domain.Entities;
using Watchlist.Domain.Interfaces;

namespace Watchlist.API.Requests.Queries
{
    public class GetWatchlistQueryHandler : IRequestHandler<GetWatchlistQuery, IEnumerable<WatchlistItem>>
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public GetWatchlistQueryHandler(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public async Task<IEnumerable<WatchlistItem>> Handle(GetWatchlistQuery request, CancellationToken cancellationToken)
        {
            return await _watchlistRepository.GetWatchlistForUserAsync(request.UserId);
        }
    }
}
