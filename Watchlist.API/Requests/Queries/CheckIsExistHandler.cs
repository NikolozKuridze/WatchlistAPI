using MediatR;
using Watchlist.Domain.Interfaces;

namespace Watchlist.API.Requests.Queries
{
    public class CheckIsExistHandler : IRequestHandler<CheckIsExistQuery, bool>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public CheckIsExistHandler(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(CheckIsExistQuery request, CancellationToken cancellationToken)
        {
            switch (request.CheckIsExistEnum)
            {
                case Domain.CheckIsExistEnum.Movie:
                    return await _movieRepository.IsExist(request.id);
                case Domain.CheckIsExistEnum.User:
                    return await _userRepository.IsExist(request.id);
                default:
                    return false;
            }
        }
    }
}
