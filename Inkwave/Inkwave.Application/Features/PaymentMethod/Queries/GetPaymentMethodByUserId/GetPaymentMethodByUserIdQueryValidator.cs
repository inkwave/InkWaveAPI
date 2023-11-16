using FluentValidation;

namespace Inkwave.Application.Features.PaymentMethod.Queries.GetPaymentMethodByUserId
{
    public class GetPaymentMethodByUserIdQueryValidator : AbstractValidator<GetPaymentMethodByUserIdQuery> 
    {
        public GetPaymentMethodByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
        }


    }
}
