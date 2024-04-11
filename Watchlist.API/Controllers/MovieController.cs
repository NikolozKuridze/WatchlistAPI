using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watchlist.API.Requests.Queries;

namespace Watchlist.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        #region Private Members

        private readonly IMediator _mediator;

        #endregion

        #region Constructors

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Actions

        [HttpGet("search-movie-by-title")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
            var result = await _mediator.Send(new GetMoviesQuery(title));
            return Ok(result);
        }

        #endregion

    }
}
