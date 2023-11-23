using Inkwave.Application.Features.PaymentMethods.Commands.AddPaymentMethod;
using Inkwave.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod;
using Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodByUserId;

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
        public async Task<ActionResult<Result<Guid>>> AddPaymentMethod(AddPaymentMethodCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId) && userId == command.UserId)
                return await _mediator.Send(command);
            return Result<Guid>.Failure("Not Found");
        }

        [HttpPut()]
        public async Task<ActionResult<Result<Guid>>> UpdatePaymentMethod(UpdatePaymentMethodCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId) && userId == command.UserId)
                return await _mediator.Send(command);
            return Result<Guid>.Failure("Not Found");
        }

        [HttpGet()]
        public async Task<ActionResult<Result<List<GetPaymentMethodByUserIdDto>>>> GetPaymentMethodByUserId()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new GetPaymentMethodByUserIdQuery
                {
                    UserId = userId
                });
            return Result<List<GetPaymentMethodByUserIdDto>>.Failure("Not Found");
        }

    }
}
