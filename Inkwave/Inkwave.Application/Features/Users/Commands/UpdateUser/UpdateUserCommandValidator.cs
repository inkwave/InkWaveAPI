using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateUserCommandValidator(IUnitOfWork unitOfWork)
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
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                RuleFor(p => p)
                    .MustAsync(IsUniqueEmail).WithMessage("{PropertyName} already exists.");
            }
        }
        private async Task<bool> IsUniqueEmail(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userObject = await unitOfWork.Repository<User>().Entities.AnyAsync(x => x.Id != command.UserId && x.Email.Trim().ToLower() == command.Email.Trim().ToLower());
            if (userObject)
                return false;

            return true;
        }
    }
}
