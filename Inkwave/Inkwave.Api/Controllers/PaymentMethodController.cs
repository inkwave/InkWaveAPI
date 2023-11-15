using Inkwave.Application.Features.PaymentMethod.Commands.AddPaymentMethod;
using Inkwave.Application.Features.PaymentMethod.Commands.UpdatePaymentMethod;

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
        public async Task<ActionResult<Result<Guid>>> AddPaymentMethod(string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new AddPaymentMethodCommand
                {
                    UserId = userId,
                    CardName = cardName,
                    CardNumber = cardNumber,
                    CardMonth = cardMonth,
                    CardYear = cardYear,
                    CardCVV = cardCvv
                });
            return Result<Guid>.Failure("Not Found");
        }

        [HttpPut()]
        public async Task<ActionResult<Result<Guid>>> UpdatePaymentMethod(Guid id, string cardName, string cardNumber, string cardMonth, string cardYear, string cardCvv)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new UpdatePaymentMethodCommand
                {
                    Id = id,
                    UserId = userId,
                    CardName = cardName,
                    CardNumber = cardNumber,
                    CardMonth = cardMonth,
                    CardYear = cardYear,
                    CardCVV = cardCvv
                });
            return Result<Guid>.Failure("Not Found");
        }

    }
}
