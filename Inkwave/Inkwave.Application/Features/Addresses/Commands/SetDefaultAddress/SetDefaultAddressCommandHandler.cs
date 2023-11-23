using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Addresses.Commands.SetDefaultAddress;

internal class SetDefaultAddressCommandHandler : IRequestHandler<SetDefaultAddressCommand, Result<Guid>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IAddressRepository AddressRepository;

    public SetDefaultAddressCommandHandler(IUnitOfWork unitOfWork, IAddressRepository AddressRepository)
    {
        this.unitOfWork = unitOfWork;
        this.AddressRepository = AddressRepository;
    }

    public async Task<Result<Guid>> Handle(SetDefaultAddressCommand command, CancellationToken cancellationToken)
    {
        await AddressRepository.UpdateDefaultAddres(command.Id, command.UserId);
        await unitOfWork.Save(cancellationToken);
        var result = await unitOfWork.Save(cancellationToken);
        if (result > 0)
            return await Result<Guid>.SuccessAsync(command.Id, "Updated Address.");
        else
            return await Result<Guid>.FailureAsync("error in the code");

    }



}
