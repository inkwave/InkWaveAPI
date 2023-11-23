using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Addresses.Queries.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Result<GetAddressByIdDto>>
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IAddressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetAddressByIdDto>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {

            var Address = await _AddressRepository.GetById(request.Id);

            if (Address == null)
            {
                return Result<GetAddressByIdDto>.Failure($"Address Not Found.");
            }

            var mappedAddress = _mapper.Map<GetAddressByIdDto>(Address);

            return Result<GetAddressByIdDto>.Success(mappedAddress);

        }
    }
}
