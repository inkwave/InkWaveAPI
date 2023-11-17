using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Address.Commands.AddAddress
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, Result<Guid>>
    {
        private readonly IAddressRepository AddressRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AddAddressCommandHandler(IAddressRepository AddressRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.AddressRepository = AddressRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var Address = await AddressRepository.CreateAddressAsync(request.UserId, request.Street, request.City, request.Building, request.Apartment, request.MarkingPlace);
            var result = await unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<Guid>.SuccessAsync(Address.Id, "Address Added.");
            else
                return await Result<Guid>.FailureAsync("error in the code");

        }
    }

}
