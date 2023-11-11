using Inkwave.Application.Features.Favourites.Commands.AddFavourite;
using Inkwave.Application.Features.Favourites.Commands.RemoveFavourite;
using Inkwave.Application.Features.Favourites.Queries.GetMyFavourite;
using Inkwave.Infrastructure.Authentication;
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
        public async Task<ActionResult<Result<Guid>>> AddFavourite(Guid itemId)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new AddFavouriteCommand { UserId = userId, ItemId = itemId });
            return Result<Guid>.Failure("Not Found");
        }



        [HttpDelete()]
        public async Task<ActionResult<Result<Guid>>> RemoveFavourite(Guid itemId)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new RemoveFavouriteCommand { UserId = userId, ItemId = itemId });
            else
                return Result<Guid>.Failure("Not Found");
        }

        [HttpGet()]
        public async Task<ActionResult<Result<List<GetMyFavouriteDto>>>> GetMyFavourite()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new GetMyFavouriteQuery(userId));
            else
                return Result<List<GetMyFavouriteDto>>.Failure("Not Found");

        }


    }
}
