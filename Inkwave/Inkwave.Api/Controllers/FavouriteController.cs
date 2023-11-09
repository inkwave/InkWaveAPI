using Inkwave.Application.Features.Favourites.Commands.AddFavourite;
using Inkwave.Application.Features.Favourites.Commands.RemoveFavourite;
using Inkwave.Application.Features.Favourites.Queries.GetMyFavourite;
using Inkwave.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class FavouriteController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public FavouriteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<ActionResult<Result<Guid>>> AddFavourite(AddFavouriteCommand command)
        {
            return await _mediator.Send(command);
        }



        [HttpDelete()]
        public async Task<ActionResult<Result<Guid>>> RemoveFavourite(RemoveFavouriteCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet()]
        public async Task<ActionResult<Result<GetMyFavouriteDto>>> GetMyFavourite(Guid id)
        {
            return await _mediator.Send(new GetMyFavouriteQuery(id));
        }
        

    }
}
