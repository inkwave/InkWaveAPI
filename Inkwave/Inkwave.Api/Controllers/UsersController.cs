using Inkwave.Application.Features.Users.Commands.DeleteUser;
using Inkwave.Application.Features.Users.Commands.UpdateUser;
using Inkwave.Application.Features.Users.Queries.GetUsersWithPagination;
using Inkwave.Infrastructure.Authentication;
using Inkwave.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inkwave.WebAPI.Controllers
{
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllUsersDto>>>> Get()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetUserByIdDto>>> GetUsersById(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }
        [HttpGet()]
        [Route("GetMyInfo")]
        public async Task<ActionResult<Result<GetUserByIdDto>>> GetMyInfo()
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid UserId))
                return await GetUsersById(UserId);
            else
                return Result<GetUserByIdDto>.Failure("Not Found");
        }
        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetUsersWithPaginationDto>>> GetUsersWithPagination([FromQuery] GetUsersWithPaginationQuery query)
        {
            var validator = new GetUsersWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteUserCommand(id));
        }
    }
}
