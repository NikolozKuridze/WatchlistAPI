using MediatR;
using Watchlist.Domain.Entities;

namespace Watchlist.API.Requests.Queries
{
    public record GetMoviesQuery(string Title) : IRequest<IEnumerable<Movie>>;
}
