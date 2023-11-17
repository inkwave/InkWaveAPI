using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodByUserId
{
    public class GetPaymentMethodByUserIdQueryHandler : IRequestHandler<GetPaymentMethodByUserIdQuery, Result<List<GetPaymentMethodByUserIdDto>>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;

        public GetPaymentMethodByUserIdQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetPaymentMethodByUserIdDto>>> Handle(GetPaymentMethodByUserIdQuery request, CancellationToken cancellationToken)
        {
            var paymentMethods = await _paymentMethodRepository.GetAllPaymentMethodsByUserId(request.UserId);
            var paymentMethodsDto = _mapper.Map<List<GetPaymentMethodByUserIdDto>>(paymentMethods);
            return Result<List<GetPaymentMethodByUserIdDto>>.Success(paymentMethodsDto);
        }
    }
}
