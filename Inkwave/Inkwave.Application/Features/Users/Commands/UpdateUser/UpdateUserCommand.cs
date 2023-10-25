using AutoMapper;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Entities;
using Inkwave.Shared;

using MediatR;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }

        public async Task<Result<Guid>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var User = await _unitOfWork.Repository<User>().GetByIdAsync(command.Id);
            if (User != null)
            {
                User.Name = command.Name;
                User.Email = command.Email;

                await _unitOfWork.Repository<User>().UpdateAsync(User);
                User.AddDomainEvent(new UserUpdatedEvent(User));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(User.Id, "User Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("User Not Found.");
            }               
        }
    }
}
