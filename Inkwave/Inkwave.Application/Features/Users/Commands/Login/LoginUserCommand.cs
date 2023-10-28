using Inkwave.Application.Common;
using Inkwave.Application.Interfaces;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Authentication;
using Inkwave.Domain.Entities;
using Inkwave.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.LoginUser
{
    public record LoginUserCommand : IRequest<Result<AuthResult>> 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<AuthResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider jwtProvider;
        public LoginUserCommandHandler(IUnitOfWork unitOfWork,IJwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            this.jwtProvider = jwtProvider;
        }

        public async Task<Result<AuthResult>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<User>().Entities.FirstOrDefaultAsync(x => x.Email == command.Email, cancellationToken);
            if (entity == null)
                return await Result<AuthResult>.FailureAsync("not found");

            if (!PasswordSecurity.VeryfypasswordHash(command.Password, entity.passwordHash, entity.passwordSalt))
                return await Result<AuthResult>.FailureAsync("email or password failuer");

            var token = jwtProvider.GenerateToken(entity);
            return await Result<AuthResult>.SuccessAsync(token, "Token");
        }
    }
}
