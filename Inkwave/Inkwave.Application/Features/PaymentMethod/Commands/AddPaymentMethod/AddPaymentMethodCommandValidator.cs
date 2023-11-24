using FluentValidation;

namespace Inkwave.Application.Features.PaymentMethods.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommandValidator : AbstractValidator<AddPaymentMethodCommand>
    {
        public AddPaymentMethodCommandValidator()
        {
            RuleFor(p => p.CardNumber)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                .MinimumLength(16).WithMessage("{PropertyName} must not minimum 16 characters.")
                .MaximumLength(19).WithMessage("{PropertyName} must not maximum 19 characters.");

            RuleFor(p => p.CardMonth)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(2).WithMessage("{PropertyName} must not exceed 2 characters.");

            RuleFor(p => p.CardYear)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(4).WithMessage("{PropertyName} must not exceed 4 characters.");

            RuleFor(p => p.CardCVV)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(3).WithMessage("{PropertyName} must not exceed 3 characters.");

            RuleFor(p => p)
                .Must(IsExpiredDate).WithMessage("expired date.");
        }

        private bool IsExpiredDate(AddPaymentMethodCommand command)
        {
            if (int.TryParse(command.CardYear, out int year) && int.TryParse(command.CardMonth, out int month))
            {
                var date = new DateTime(year, month, 1);
                return date.Date > DateTime.UtcNow.Date;
            }
            return false;
        }
    }
}
