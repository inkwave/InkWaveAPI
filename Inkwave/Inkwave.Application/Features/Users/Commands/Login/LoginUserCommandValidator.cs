using FluentValidation;
using Inkwave.Application.Features.Users.Commands.LoginUser;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginUserCommandValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            {
                RuleFor(p => p.Email)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .EmailAddress()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                RuleFor(p => p).MustAsync(IsActive).WithMessage("email not not active.");

                RuleFor(p => p.Password)
                    .NotEmpty()
                    .WithMessage("{PropertyName} is required.")
                    .NotNull();

            }
        }
        private async Task<bool> IsActive(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var userObject = await unitOfWork.Repository<User>().Entities.AnyAsync(x => x.Email.Trim().ToLower() == command.Email.Trim().ToLower() && x.Active);
            if (userObject)
                return true;
            return false;
        }
    }
}
