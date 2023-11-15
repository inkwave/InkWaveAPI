using AutoMapper;
using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.PaymentMethod.Commands.UpdatePaymentMethod
{
    internal class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, Result<Guid>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentMethodRepository paymentMethodRepository; 
        private readonly IMapper mapper;

        public UpdatePaymentMethodCommandHandler(IUnitOfWork unitOfWork, IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.paymentMethodRepository = paymentMethodRepository;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdatePaymentMethodCommand command, CancellationToken cancellationToken)
        {
            var paymentMethod = await paymentMethodRepository.GetById(command.Id);
            if (paymentMethod == null)
                return await Result<Guid>.FailureAsync("PaymentMethod not found.");

            paymentMethod = mapper.Map<Domain.PaymentMethod.PaymentMethod>(command);
            await paymentMethodRepository.Update(paymentMethod);
            await unitOfWork.Save(cancellationToken);

            return await Result<Guid>.SuccessAsync(paymentMethod.Id, "PaymentMethod updated.");


        }


        
    }
}
