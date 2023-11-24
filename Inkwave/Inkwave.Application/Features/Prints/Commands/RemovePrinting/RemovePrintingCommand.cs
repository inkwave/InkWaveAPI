namespace Inkwave.Application.Features.Prints.Commands.RemovePrinting;

public class RemovePrintingCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
}
