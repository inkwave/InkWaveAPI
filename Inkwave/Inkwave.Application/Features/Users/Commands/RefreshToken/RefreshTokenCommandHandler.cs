using Inkwave.Application.Interfaces;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Authentication;
using Inkwave.Domain.User;
using Inkwave.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<Result<AuthResult>>
{
    public string Token { get; set; }
}

internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtProvider jwtProvider;
    public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, IJwtProvider jwtProvider)
    {
        _unitOfWork = unitOfWork;
        this.jwtProvider = jwtProvider;
    }

    public async Task<Result<AuthResult>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var principal = jwtProvider.GetPrincipalFromExpiredToken(command.Token);
        if (principal == null) return await Result<AuthResult>.FailureAsync("not found");
        var entity = await _unitOfWork.Repository<User>().Entities.FirstOrDefaultAsync(x => x.Email == principal.Claims.First(x => x.Type == "email").Value, cancellationToken);
        if (entity == null)
            return await Result<AuthResult>.FailureAsync("not found");

        var token = jwtProvider.GenerateToken(entity);
        return await Result<AuthResult>.SuccessAsync(token, "Token");
    }
}
