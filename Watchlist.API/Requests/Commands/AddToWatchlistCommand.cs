using MediatR;
using Watchlist.API.Models;
using Watchlist.Domain.Entities; 

namespace Watchlist.API.Requests.Commands
{
    public record AddToWatchlistCommand(AddWatchlistItemModel model) : IRequest<WatchlistItem>; 
}
