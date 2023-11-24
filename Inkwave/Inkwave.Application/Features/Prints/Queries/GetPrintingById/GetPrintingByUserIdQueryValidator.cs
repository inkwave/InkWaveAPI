using FluentValidation;

namespace Inkwave.Application.Features.Orders.Queries.GetOrdersById;

public class GetPrintingByIdQueryValidator : AbstractValidator<GetPrintingByIdQuery>
{
    public GetPrintingByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }


}
