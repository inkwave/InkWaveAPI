using FluentValidation;
using Inkwave.Application.Features.Users.Commands.ActiveUser;
using Inkwave.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inkwave.Application.Features.Users.Commands.ResendActiveCode
{
    public class SendActiveCodeCommandValidator : AbstractValidator<SendActiveCodeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendActiveCodeCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsFoundEmail).WithMessage("email not  found.");

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
