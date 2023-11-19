using FluentValidation;

namespace Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodByUserId
{
    public class GetPaymentMethodByUserIdQueryValidator : AbstractValidator<GetPaymentMethodByUserIdQuery>
    {
        public GetPaymentMethodByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }


    }
}
