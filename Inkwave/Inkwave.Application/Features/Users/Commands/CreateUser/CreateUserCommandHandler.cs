using AutoMapper;
using Inkwave.Application.Common;
using Inkwave.Application.Interfaces;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Entities;
using Inkwave.Shared;
using MediatR;

namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService emailService;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork ,IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            this.emailService = emailService;
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
            _ = emailService.SendWelcomeEmailAsync(command.Email);
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(User.Id, "User Created.");
        }
    }
}
