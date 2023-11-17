using Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder;
using Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class OrderController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<ActionResult<Result<List<GetOrdersByUserIdDto>>>> GetOrdersByUserId()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new GetOrdersByUserIdQuery { UserId = userId });
            else
                return Result<List<GetOrdersByUserIdDto>>.Failure("Not Found");

        }
        [HttpPost()]
        [Route("CreateFromCartOrder")]
        public async Task<ActionResult<Result<Order>>> CreateFromCartOrder(Guid addressId, bool isCashOnDelivery, Guid paymentMethodId)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new CreateFromCartOrderCommand
                {
                    UserId = userId,
                    AddressId = addressId,
                    IsCashOnDelivery = isCashOnDelivery,
                    PaymentMethodId = paymentMethodId
                });
            return Result<Order>.Failure("Not Found");
        }


        //[HttpDelete()]
        //public async Task<ActionResult<Result<Guid>>> RemoveCart(Guid itemId)
        //{
        //    if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
        //        return await _mediator.Send(new RemoveCartCommand { UserId = userId, ItemId = itemId });
        //    else
        //        return Result<Guid>.Failure("Not Found");


        //}
    }
}
