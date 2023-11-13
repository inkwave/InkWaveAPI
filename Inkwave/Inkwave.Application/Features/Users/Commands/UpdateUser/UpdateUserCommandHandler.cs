using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.User;
namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(command.Id);
            if (user == null) return await Result<Guid>.FailureAsync("User Not Found.");
            user.UpdateUser(command.FirstName, command.LastName, command.Email, command.Phone, command.Gender);
            await _unitOfWork.Repository<User>().UpdateAsync(user);
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(user.Id, "User Updated.");
        }
    }
}
