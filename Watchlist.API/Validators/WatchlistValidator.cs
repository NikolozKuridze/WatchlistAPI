using FluentValidation;
using MediatR;
using Watchlist.API.Models;
using Watchlist.API.Requests.Queries;
using Watchlist.Domain.Entities;

namespace Watchlist.API.Validators
{
    public class WatchlistItemValidator : AbstractValidator<AddWatchlistItemModel>
    {
        #region Private Members
        private readonly IMediator _mediator;
        #endregion

        #region Private Methods
        private async Task<bool> MovieIsExist(int id, CancellationToken token)
        {
            return await _mediator.Send(new CheckIsExistQuery(id, Domain.CheckIsExistEnum.Movie));
        }

        private async Task<bool> UserIsExist(int id, CancellationToken token)
        {
            return await _mediator.Send(new CheckIsExistQuery(id, Domain.CheckIsExistEnum.User));
        }

        #endregion

        #region Constructors
        public WatchlistItemValidator(IMediator mediator)
        {
            RuleFor(wi => wi.UserId).MustAsync(UserIsExist).WithMessage("User not found");
            RuleFor(wi => wi.MovieId).MustAsync(MovieIsExist).WithMessage("movie not found");
            _mediator = mediator;
        } 
        #endregion

    }
}
