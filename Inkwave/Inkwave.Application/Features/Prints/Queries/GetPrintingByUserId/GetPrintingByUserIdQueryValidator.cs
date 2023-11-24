using FluentValidation;

namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetPrintingByUserIdQueryValidator : AbstractValidator<GetPrintingByUserIdQuery>
{
    public GetPrintingByUserIdQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
    }


}
