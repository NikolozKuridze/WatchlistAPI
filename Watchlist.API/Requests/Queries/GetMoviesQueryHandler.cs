using MediatR;
using Watchlist.Domain.Entities;
using Watchlist.Domain.Interfaces;

namespace Watchlist.API.Requests.Queries
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.SearchByTitleAsync(request.Title);
        }
    }
}
