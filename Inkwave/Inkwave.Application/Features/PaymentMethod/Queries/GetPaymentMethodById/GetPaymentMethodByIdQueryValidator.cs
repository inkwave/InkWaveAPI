using FluentValidation;

namespace Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodById
{
    public class GetPaymentMethodByIdQueryValidator : AbstractValidator<GetPaymentMethodByIdQuery>
    {
        public GetPaymentMethodByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
