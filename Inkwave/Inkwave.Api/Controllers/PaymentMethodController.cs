using Inkwave.Application.Features.PaymentMethod.Commands;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class PaymentMethodController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]

        public async Task<IActionResult> AddPaymentMethod(AddPaymentMethodCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
