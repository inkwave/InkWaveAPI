using Inkwave.Application.Features.Payments.Commands.AddPayment;
using Inkwave.Application.Features.Payments.Commands.RemovePayment;
using Inkwave.Application.Features.Payments.Queries.GetPaymentById;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class PaymentController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]

        public async Task<ActionResult<Result<Guid>>> AddPayment(Guid id)
        {
            var command = new AddPaymentCommand() { OrderId = id };
            return await _mediator.Send(command);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Guid>>> RemovePayment(Guid id)
        {
            var command = new RemovePaymentCommand() { ItemId = id };
            return await _mediator.Send(command);
        }

       
    }
}
