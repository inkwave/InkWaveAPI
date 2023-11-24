using Inkwave.Application.Features.Users.Commands.ChangePassword;
using Inkwave.Application.Features.Users.Commands.DeleteUser;
using Inkwave.Application.Features.Users.Commands.UpdateUser;
using Inkwave.Application.Features.Users.Commands.UpdateUserPhoto;
using Inkwave.Application.Features.Users.Queries.GetUsersWithPagination;

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

        [HttpPost()]
        [Route("ChangePassword")]
        public async Task<ActionResult<Result<bool>>> ChangePassword(ChangePasswordCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid UserId) && (UserId == command.UserId))
                return await _mediator.Send(command);
            return Result<bool>.Failure("Not Found");
        }

        [HttpPut()]
        public async Task<ActionResult<Result<Guid>>> Update(UpdateUserCommand command)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid UserId) && (UserId == command.UserId))
                return await _mediator.Send(command);
            return Result<Guid>.Failure("Not Found");
        }
        [HttpPut()]
        [Route("UpdatePhoto")]
        public async Task<ActionResult<Result<Guid>>> UpdatePhoto(string photoUrl)
        {
            if (Guid.TryParse(this.User.Claims.First(i => i.Type == ClaimName.UserId).Value, out Guid userId))
                return await _mediator.Send(new UpdateUserPhotoCommand { UserId = userId, PhotoUrl = photoUrl });
            return Result<Guid>.Failure("Not Found");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteUserCommand(id));
        }
    }
}
