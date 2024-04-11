using MediatR;
using Watchlist.Domain; 

namespace Watchlist.API.Requests.Queries
{
    public record CheckIsExistQuery(int id,CheckIsExistEnum CheckIsExistEnum) : IRequest<bool>; 
}
