using FluentValidation;

namespace Inkwave.Application.Features.Prints.Commands.RemovePrinting;

public class RemovePrintingCommandValidator : AbstractValidator<RemovePrintingCommand>
{
    public RemovePrintingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull();

    }
}
