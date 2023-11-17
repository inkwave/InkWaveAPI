using FluentValidation;

namespace Inkwave.Application.Features.Payments.Commands.RemovePayment
{
    internal class RemovePaymentCommandValidator : AbstractValidator<RemovePaymentCommand>
    {
        public RemovePaymentCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{UserId} is required.")
                .NotNull();
            RuleFor(p => p.ItemId)
                .NotEmpty().WithMessage("{ItemId} is required.")
                .NotNull();
        }
    }
}
