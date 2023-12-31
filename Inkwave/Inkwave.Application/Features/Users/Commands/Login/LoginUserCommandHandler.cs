﻿using Inkwave.Application.Interfaces;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<AuthResult>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider jwtProvider;
        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            this.jwtProvider = jwtProvider;
        }

        public async Task<Result<AuthResult>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<User>().Entities.FirstOrDefaultAsync(x => x.Email == command.Email, cancellationToken);
            if (entity == null)
                return await Result<AuthResult>.FailureAsync("not found");

            if (!entity.VerifyPassword(command.Password))
                return await Result<AuthResult>.FailureAsync("email or password failuer");

            var token = jwtProvider.GenerateToken(entity);
            return await Result<AuthResult>.SuccessAsync(token, "Token");
        }
    }
}
