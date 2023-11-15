using Inkwave.Application.Features.Favourites.Commands.AddFavourite;
using Inkwave.Application.Features.Favourites.Commands.RemoveFavourite;
using Inkwave.Application.Features.Favourites.Queries.GetMyFavourite;
using Inkwave.Application.Features.Payments.Commands.AddPayment;


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
        


    }
}
