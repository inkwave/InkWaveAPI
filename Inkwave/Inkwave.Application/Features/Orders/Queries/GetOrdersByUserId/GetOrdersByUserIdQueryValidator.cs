using FluentValidation;

namespace Inkwave.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQueryValidator : AbstractValidator<GetOrdersByUserIdQuery>
{
    public GetOrdersByUserIdQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
    }


}
