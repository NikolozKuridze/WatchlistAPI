using MediatR;
using Watchlist.Domain.Entities;
using Watchlist.Domain.Interfaces;

namespace Watchlist.API.Requests.Commands
{
    public class AddToWatchlistCommandHandler : IRequestHandler<AddToWatchlistCommand, WatchlistItem>
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public AddToWatchlistCommandHandler(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public async Task<WatchlistItem> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            return await _watchlistRepository.AddToWatchlistAsync(request.model.UserId, request.model.MovieId);
        }
    }
}
