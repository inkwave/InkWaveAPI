using FluentValidation;

namespace Inkwave.Application.Features.Orders.Commands.CreateFromCartOrder;

public class CreateFromCartOrderCommandValidator : AbstractValidator<CreateFromCartOrderCommand>
{
    public CreateFromCartOrderCommandValidator()
    {

        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.AddressId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x).Must(IsCashOnDeliveryValidat).WithMessage("{PropertyName} should be not empty. NEVER!");
    }
    public bool IsCashOnDeliveryValidat(CreateFromCartOrderCommand command)
    {
        if (command.IsCashOnDelivery == false && command.PaymentMethodId == null)
            return false;
        else return true;
    }
}
