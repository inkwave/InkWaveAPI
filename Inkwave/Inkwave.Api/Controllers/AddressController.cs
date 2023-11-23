using Inkwave.Application.Features.Addresses.Commands.AddAddress;
using Inkwave.Application.Features.Addresses.Commands.SetDefaultAddress;
using Inkwave.Application.Features.Addresses.Commands.UpdateAddress;
using Inkwave.Application.Features.Addresses.Queries.GetAddressByUserId;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class AddressController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<ActionResult<Result<Guid>>> AddAddress(AddAddressCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId) && userId == command.UserId)
                return await _mediator.Send(command);
            return Result<Guid>.Failure("Not Found");
        }
        [HttpPost()]
        [Route("SetDefault/{id}")]
        public async Task<ActionResult<Result<Guid>>> SetDefault(Guid id)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new SetDefaultAddressCommand { Id = id, UserId = userId });
            return Result<Guid>.Failure("Not Found");
        }

        [HttpPut()]
        public async Task<ActionResult<Result<Guid>>> UpdateAddress(UpdateAddressCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId) && userId == command.UserId)
                return await _mediator.Send(command);
            return Result<Guid>.Failure("Not Found");
        }

        [HttpGet()]
        public async Task<ActionResult<Result<List<GetAddressByUserIdDto>>>> GetAddressByUserId()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new GetAddressByUserIdQuery
                {
                    UserId = userId
                });
            return Result<List<GetAddressByUserIdDto>>.Failure("Not Found");
        }

    }
}
