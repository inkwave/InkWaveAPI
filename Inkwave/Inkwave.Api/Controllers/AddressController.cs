using Inkwave.Application.Features.Address.Commands.AddAddress;
using Inkwave.Application.Features.Address.Commands.UpdateAddress;
using Inkwave.Application.Features.Address.Queries.GetAddressByUserId;

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
        public async Task<ActionResult<Result<Guid>>> AddAddress(string street, string city, string building, string apartment, string markingPlace)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new AddAddressCommand
                {
                    UserId = userId,
                    Street = street,
                    City = city,
                    Building = building,
                    Apartment = apartment,
                    MarkingPlace = markingPlace
                });
            return Result<Guid>.Failure("Not Found");
        }

        [HttpPut()]
        public async Task<ActionResult<Result<Guid>>> UpdateAddress(Guid id, string street, string city, string building, string apartment, string markingPlace)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new UpdateAddressCommand
                {
                    Id = id,
                    UserId = userId,
                    Street = street,
                    City = city,
                    Building = building,
                    Apartment = apartment,
                    MarkingPlace = markingPlace
                });
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
