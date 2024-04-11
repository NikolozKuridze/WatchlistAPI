using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc; 
using Watchlist.API.Models;
using Watchlist.API.Requests.Commands;
using Watchlist.API.Requests.Queries; 

namespace Watchlist.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchlistController : ControllerBase
    {
        #region Private Members

        private readonly IMediator _mediator;

        #endregion

        #region Constructors

        public WatchlistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Actions

        [HttpPost("add-movie-to-watchlist")]
        public async Task<IActionResult> AddToWatchlist(AddWatchlistItemModel model, [FromServices] IValidator<AddWatchlistItemModel> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var result = await _mediator.Send(new AddToWatchlistCommand(model));
            return CreatedAtAction(nameof(AddToWatchlist), result);
        }

        [HttpGet("get-watchlist")]
        public async Task<IActionResult> GetWatchlist(int userId)
        {
            var result = await _mediator.Send(new GetWatchlistQuery(userId));
            return Ok(result);
        }

        [HttpPatch("movie-is-watched/{movieId}")]
        public async Task<IActionResult> MarkMovieAsWatched(int userId, int movieId)
        {
            await _mediator.Send(new MarkMovieAsWatchedCommand(userId, movieId));
            return NoContent();
        }

        #endregion  
    }
}
