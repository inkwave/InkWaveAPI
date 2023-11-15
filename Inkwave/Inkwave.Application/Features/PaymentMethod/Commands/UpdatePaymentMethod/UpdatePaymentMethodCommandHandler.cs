using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.PaymentMethod.Commands.UpdatePaymentMethod
{
    internal class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, Result<Guid>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPaymentMethodRepository paymentMethodRepository;

        public UpdatePaymentMethodCommandHandler(IUnitOfWork unitOfWork, IPaymentMethodRepository paymentMethodRepository)
        {
            this.unitOfWork = unitOfWork;
            this.paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<Result<Guid>> Handle(UpdatePaymentMethodCommand command, CancellationToken cancellationToken)
        {
            await paymentMethodRepository.UpdatePaymentMethod(command.Id, command.UserId, command.CardName, command.CardNumber, command.CardMonth, command.CardYear, command.CardCVV);
            await unitOfWork.Save(cancellationToken);
            var result = await unitOfWork.Save(cancellationToken);
            if (result > 0)
                return await Result<Guid>.SuccessAsync(command.Id, "Updated Cart.");
            else
                return await Result<Guid>.FailureAsync("error in the code");

        }



    }
}
