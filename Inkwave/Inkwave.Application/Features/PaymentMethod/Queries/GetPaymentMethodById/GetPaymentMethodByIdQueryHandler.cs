using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.PaymentMethod.Queries.GetPaymentMethodById
{
    public class GetPaymentMethodByIdQueryHandler : IRequestHandler<GetPaymentMethodByIdQuery, Result<GetPaymentMethodByIdDto>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;

        public GetPaymentMethodByIdQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetPaymentMethodByIdDto>> Handle(GetPaymentMethodByIdQuery request, CancellationToken cancellationToken)
        {

            var paymentMethod = await _paymentMethodRepository.GetPaymentMethodById(request.Id);

            if (paymentMethod == null)
            {
                return Result<GetPaymentMethodByIdDto>.Failure($"PaymentMethod Not Found.");
            }

            var mappedPaymentMethod = _mapper.Map<GetPaymentMethodByIdDto>(paymentMethod);

            return Result<GetPaymentMethodByIdDto>.Success(mappedPaymentMethod);
            
        }
    }
}
