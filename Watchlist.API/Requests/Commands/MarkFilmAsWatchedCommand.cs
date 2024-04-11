using MediatR;
namespace Watchlist.API.Requests.Commands
{
    public record MarkMovieAsWatchedCommand(int UserId, int MovieId) : IRequest<Unit>;
}
