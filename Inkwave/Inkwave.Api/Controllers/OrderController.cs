using Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateCancelled;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateClosed;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateConfirmed;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateDelivered;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateInTransit;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStatePending;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStatePickupAvailable;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateProblem;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateProcessing;
using Inkwave.Application.Features.Orders.Commands.OrderStates.OrderStateReturned;
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
        [HttpPost()]
        [Authorize(Roles = "Admin")]
        [Route("OrderState/{state}/{id}")]
        public async Task<ActionResult<Result<Order>>> OrderState(string state, Guid id, string? description)
        {
            if (Enum.TryParse<OrderStates>(state, false, out OrderStates orderState))
            {
                switch (orderState)
                {
                    case OrderStates.Pending:
                        return await _mediator.Send(new OrderStatePendingCommand { OrderId = id });
                    case OrderStates.Confirmed:
                        return await _mediator.Send(new OrderStateConfirmedCommand { OrderId = id });
                    case OrderStates.Cancelled:
                        return await _mediator.Send(new OrderStateCancelledCommand { OrderId = id, Description = description });
                    case OrderStates.Processing:
                        return await _mediator.Send(new OrderStateProcessingCommand { OrderId = id });
                    case OrderStates.PickupAvailable:
                        return await _mediator.Send(new OrderStatePickupAvailableCommand { OrderId = id });
                    case OrderStates.InTransit:
                        return await _mediator.Send(new OrderStateInTransitCommand { OrderId = id });
                    case OrderStates.Delivered:
                        return await _mediator.Send(new OrderStateDeliveredCommand { OrderId = id });
                    case OrderStates.Problem:
                        return await _mediator.Send(new OrderStateProblemCommand { OrderId = id, Description = description });
                    case OrderStates.Returned:
                        return await _mediator.Send(new OrderStateReturnedCommand { OrderId = id, Description = description });
                    case OrderStates.Closed:
                        return await _mediator.Send(new OrderStateClosedCommand { OrderId = id });
                    default:
                        break;
                }
            }

            return Result<Order>.Failure("Not Found");
        }

    }
}
