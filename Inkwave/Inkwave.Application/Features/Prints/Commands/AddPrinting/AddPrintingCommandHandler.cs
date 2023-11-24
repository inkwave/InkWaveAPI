using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Prints.Commands.AddPrinting;

public class AddPrintingCommandHandler : IRequestHandler<AddPrintingCommand, Result<Guid>>
{
    private readonly IPrintingRepository _printingRepository;
    private readonly IUnitOfWork _iunitOfWork;

    public AddPrintingCommandHandler(IPrintingRepository printingRepository, IUnitOfWork iunitOfWork)
    {
        _printingRepository = printingRepository;
        _iunitOfWork = iunitOfWork;
    }


    public async Task<Result<Guid>> Handle(AddPrintingCommand command, CancellationToken cancellationToken)
    {
        var printing = await _printingRepository.CreatePrintingAsync(command.UserId, command.File, command.BindingOption, command.PrintingColor,
          command.PaperSize, command.PaperType, command.PrintingLayout, command.PrintingSide,
           command.CoverImage, command.CoverBgSize, command.CoverPositionX, command.CoverPositionY, command.CoverRepeat, command.CoverZoom);
        var result = await _iunitOfWork.Save(cancellationToken);
        if (result > 0)
            return await Result<Guid>.SuccessAsync(printing.Id, "printing added.");
        else
            return await Result<Guid>.FailureAsync("Error adding printing.");
    }


}
