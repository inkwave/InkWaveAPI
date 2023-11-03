using FluentValidation;

namespace Inkwave.Application.Features.Users.Commands.ActiveUser
{
    public class ActiveUserCommandValidator : AbstractValidator<ActiveUserCommand>
    {

        public ActiveUserCommandValidator()
        {
            RuleFor(p => p.Code)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(6).WithMessage("{PropertyName} must not exceed 6 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
    }
}
