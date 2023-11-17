using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Address.Commands.UpdateAddress
{
    internal class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Result<Guid>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAddressRepository AddressRepository;

        public UpdateAddressCommandHandler(IUnitOfWork unitOfWork, IAddressRepository AddressRepository)
        {
            this.unitOfWork = unitOfWork;
            this.AddressRepository = AddressRepository;
        }

        public async Task<Result<Guid>> Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            await AddressRepository.UpdateAddress(command.Id, command.UserId, command.Building, command.MarkingPlace, command.Apartment, command.Street, command.City);
            await unitOfWork.Save(cancellationToken);
            var result = await unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<Guid>.SuccessAsync(command.Id, "Updated Address.");
            else
                return await Result<Guid>.FailureAsync("error in the code");

        }



    }
}
