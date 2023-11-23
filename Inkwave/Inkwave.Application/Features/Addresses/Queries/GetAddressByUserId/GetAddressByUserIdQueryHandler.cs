using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Addresses.Queries.GetAddressByUserId
{
    public class GetAddressByUserIdQueryHandler : IRequestHandler<GetAddressByUserIdQuery, Result<List<GetAddressByUserIdDto>>>
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _mapper;

        public GetAddressByUserIdQueryHandler(IAddressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAddressByUserIdDto>>> Handle(GetAddressByUserIdQuery request, CancellationToken cancellationToken)
        {
            var Addresss = await _AddressRepository.GetAllAddressByUserId(request.UserId);
            var AddresssDto = _mapper.Map<List<GetAddressByUserIdDto>>(Addresss);
            return Result<List<GetAddressByUserIdDto>>.Success(AddresssDto);
        }
    }
}
