using FluentValidation;

namespace Inkwave.Application.Features.Payments.Commands.AddPayment
{
    public class AddPaymentCommandValidator : AbstractValidator<AddPaymentCommand>
    {
        public AddPaymentCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PaymentValue)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.PaymentType)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PaymentMethod)
                .NotEmpty()
                .NotNull();
        }
    }
}
