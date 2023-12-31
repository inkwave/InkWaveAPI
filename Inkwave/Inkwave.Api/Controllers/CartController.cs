﻿using Inkwave.Application.Features.Carts.Commands.AddCart;
using Inkwave.Application.Features.Carts.Commands.RemoveCart;
using Inkwave.Application.Features.Carts.Commands.UpdateQuantityCart;
using Inkwave.Application.Features.Carts.Queries.GetCartInfo;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class CartController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<ActionResult<Result<GetCartInfoDto>>> GetCartInfo()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new GetCartInfoDtoQuery { UserId = userId });
            else
                return Result<GetCartInfoDto>.Failure("Not Found");

        }
        [HttpPost()]
        public async Task<ActionResult<Result<Guid>>> AddCart(Guid itemId, double quantity)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new AddCartCommand { UserId = userId, ItemId = itemId, Quantity = quantity });
            return Result<Guid>.Failure("Not Found");
        }
        [HttpPut()]
        public async Task<ActionResult<Result<Cart>>> UpdateQuantity(Guid itemId, double quantity)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new UpdateQuantityCartCommand { UserId = userId, ItemId = itemId, Quantity = quantity });
            return Result<Cart>.Failure("Not Found");
        }

        [HttpDelete()]
        public async Task<ActionResult<Result<Guid>>> RemoveCart(Guid itemId)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new RemoveCartCommand { UserId = userId, ItemId = itemId });
            else
                return Result<Guid>.Failure("Not Found");


        }
    }
}
