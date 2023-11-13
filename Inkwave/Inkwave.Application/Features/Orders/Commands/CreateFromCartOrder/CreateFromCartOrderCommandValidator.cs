using FluentValidation;

namespace Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder;

public class CreateFromCartOrderCommandValidator : AbstractValidator<CreateFromCartOrderCommand>
{
    public CreateFromCartOrderCommandValidator()
    {

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.ShippingAddressId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.BillingAddressId)
            .NotEmpty()
            .NotNull();
    }

}
