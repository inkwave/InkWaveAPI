using AutoMapper;
using Inkwave.Application.Common.Mappings;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.User;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand : IRequest<Result<Guid>>, IMapFrom<User>
    {
        public Guid Id { get; set; }

        public DeleteUserCommand()
        {

        }

        public DeleteUserCommand(Guid id)
        {
            Id = id; 
        }
    }

    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var User = await _unitOfWork.Repository<User>().GetByIdAsync(command.Id);
            if (User != null)
            {
                await _unitOfWork.Repository<User>().DeleteAsync(User);
                User.AddDomainEvent(new UserDeletedEvent(User));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(User.Id, "Product Deleted");
            }
            else
            {
                return await Result<Guid>.FailureAsync("User Not Found.");
            }
        }
    }
}
