using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.User;
using Inkwave.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    internal class ActiveUserCommandHandler : IRequestHandler<ActiveUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActiveUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(ActiveUserCommand command, CancellationToken cancellationToken)
        {
            var User = await _unitOfWork.Repository<User>().Entities.FirstOrDefaultAsync(x => x.Email.Trim().ToLower() == command.Email.Trim().ToLower());

            if (User == null) return await Result<Guid>.FailureAsync("user hot found");

            if (User.ActiveCode != command.Code)
                return await Result<Guid>.FailureAsync("error in the code");

            User.Active = true;
            await _unitOfWork.Repository<User>().UpdateAsync(User);
            User.AddDomainEvent(new UserActivedEvent(User));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(User.Id, "user activated.");
        }
    }
}
