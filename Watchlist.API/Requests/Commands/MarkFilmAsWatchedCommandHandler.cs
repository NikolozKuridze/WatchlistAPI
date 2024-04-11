using MediatR;
using Watchlist.Domain.Interfaces;

namespace Watchlist.API.Requests.Commands
{
    public class MarkMovieAsWatchedCommandHandler : IRequestHandler<MarkMovieAsWatchedCommand, Unit>
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public MarkMovieAsWatchedCommandHandler(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public async Task<Unit> Handle(MarkMovieAsWatchedCommand request, CancellationToken cancellationToken)
        {
            await _watchlistRepository.MarkMovieAsWatchedAsync(request.UserId, request.MovieId);
            return Unit.Value;
        }
    }
}
