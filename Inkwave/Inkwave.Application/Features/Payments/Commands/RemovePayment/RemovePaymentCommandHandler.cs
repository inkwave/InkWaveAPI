using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Payments.Commands.RemovePayment
{
    public class RemovePaymentCommandHandler : IRequestHandler<RemovePaymentCommand, Result<Guid>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public RemovePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(RemovePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(request.UserId, request.ItemId);
            if (payment == null)
            {
                return Result<Guid>.Failure($"Payment with id {request.ItemId} does not exist.");
            }

            await _paymentRepository.RemovePaymentAsync(payment);
            return Result<Guid>.Success(request.ItemId);
        }
    }
}
