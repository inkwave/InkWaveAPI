using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
