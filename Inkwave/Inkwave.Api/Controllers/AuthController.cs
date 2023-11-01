using Inkwave.Application.Features.Users.Commands.ActiveUser;
using Inkwave.Application.Features.Users.Commands.CreateUser;
using Inkwave.Application.Features.Users.Commands.LoginUser;
using Inkwave.Application.Features.Users.Commands.RefreshToken;
using Inkwave.Application.Interfaces;
using Inkwave.Domain.Authentication;
using Inkwave.Infrastructure.Services;
using Inkwave.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inkwave.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmailService emailService;

        public AuthController(IMediator mediator, IEmailService emailService)
        {
            _mediator = mediator;
            this.emailService = emailService;
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
