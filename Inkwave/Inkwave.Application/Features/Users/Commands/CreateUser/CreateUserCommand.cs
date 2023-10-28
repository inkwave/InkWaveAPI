using AutoMapper;
using Inkwave.Application.Common;
using Inkwave.Application.Common.Mappings;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Entities;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand : IRequest<Result<Guid>>, IMapFrom<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            PasswordSecurity.CreatePassword(command.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var User = new User()
            {
                Name = command.Name,
                Email = command.Email,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt
            };

            await _unitOfWork.Repository<User>().AddAsync(User);
            User.AddDomainEvent(new UserCreatedEvent(User));

            await _unitOfWork.Save(cancellationToken);

            return await Result<Guid>.SuccessAsync(User.Id, "User Created.");
        }
    }
}
