using FluentValidation;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    public class ActiveUserCommandValidator : AbstractValidator<ActiveUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActiveUserCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsFoundEmail).WithMessage("email not found.");

        }
        private async Task<bool> IsFoundEmail(string email, CancellationToken cancellationToken)
        {
            var userObject = await _unitOfWork.Repository<User>().Entities.AnyAsync(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
            if (userObject)
                return true;
            return false;
        }
    }
}
