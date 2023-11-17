using Inkwave.Application.Features.Users.Commands.ActiveUser;
using Inkwave.Application.Features.Users.Commands.CreateUser;
using Inkwave.Application.Features.Users.Commands.LoginUser;
using Inkwave.Application.Features.Users.Commands.RefreshToken;
using Inkwave.Domain.Authentication;

namespace Inkwave.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<Result<Guid>>> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("ActiveUser")]
        public async Task<ActionResult<Result<Guid>>> ActiveUser(ActiveUserCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPost("SendActiveCode")]
        public async Task<ActionResult<Result<bool>>> SendActiveCode(string email)
        {
            return await _mediator.Send(new SendActiveCodeCommand { Email = email });
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Result<AuthResult>>> Login(LoginUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<Result<AuthResult>>> RefreshToken(RefreshTokenCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
