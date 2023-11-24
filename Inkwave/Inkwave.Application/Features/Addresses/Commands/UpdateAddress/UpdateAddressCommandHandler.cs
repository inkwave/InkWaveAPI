using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Addresses.Commands.UpdateAddress
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

        public async Task<Result<Guid>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            await AddressRepository.UpdateAddress(request.Id, request.UserId, request.Name, request.Country, request.Governorate, request.Street, request.City, request.District, request.Building, request.ZipCode, request.Apartment, request.MarkingPlace);
            await unitOfWork.Save(cancellationToken);
            var result = await unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<Guid>.SuccessAsync(request.Id, "Updated Address.");
            else
                return await Result<Guid>.FailureAsync("error in the code");
        }



    }
}
