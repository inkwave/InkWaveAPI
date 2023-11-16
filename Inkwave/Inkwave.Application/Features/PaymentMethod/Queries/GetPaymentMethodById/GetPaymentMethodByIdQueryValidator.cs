using FluentValidation;

namespace Inkwave.Application.Features.PaymentMethod.Queries.GetPaymentMethodById
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
