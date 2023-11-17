using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateUserCommandValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            {
                RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

                RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

                RuleFor(p => p.Password)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                RuleFor(p => p.Gender)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(8).WithMessage("{PropertyName} must not exceed 8 characters.");

                RuleFor(p => p.Phone)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

                RuleFor(p => p.Email)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .EmailAddress()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                    .MustAsync(IsUniqueEmail).WithMessage("{PropertyName} already exists.");
            }
        }
        private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var userObject = await unitOfWork.Repository<User>().Entities.AnyAsync(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
            if (userObject)
                return false;

            return true;
        }
    }
}
