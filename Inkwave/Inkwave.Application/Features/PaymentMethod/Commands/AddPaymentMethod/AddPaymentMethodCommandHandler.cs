using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.PaymentMethods.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommandHandler : IRequestHandler<AddPaymentMethodCommand, Result<Guid>>
    {
        private readonly IPaymentMethodRepository paymentMethodRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AddPaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.paymentMethodRepository = paymentMethodRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(AddPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var paymentMethod = await paymentMethodRepository.CreatePaymentMethodAsync(request.UserId, request.CardName, request.CardNumber, request.CardMonth, request.CardYear, request.CardCVV);
            var result = await unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<Guid>.SuccessAsync(paymentMethod.Id, "Payment Method Added.");
            else
                return await Result<Guid>.FailureAsync("error in the code");

        }
    }

}
