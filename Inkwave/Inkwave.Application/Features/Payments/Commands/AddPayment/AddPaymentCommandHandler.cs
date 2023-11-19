using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Payments.Commands.AddPayment
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, Result<Guid>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public AddPaymentCommandHandler(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Result<Guid>> Handle(AddPaymentCommand command, CancellationToken cancellationToken)
        {
            return default;
            //var order = await _orderRepository.GetOrderById(command.OrderId);
            //if (order == null)
            //    return await Result<Guid>.FailureAsync("Order not found.");

            //var payment = await _paymentRepository.CreatePaymentAsync(command.OrderId, command.PaymentValue, command.PaymentType, command.PaymentMethod);
            //if (payment == null)
            //    return await Result<Guid>.FailureAsync("Error creating payment.");

            //order.AddPayment(payment);
            //var result = await _orderRepository.UpdateOrderAsync(order);
            //if (result)
            //    return await Result<Guid>.SuccessAsync(command.OrderId, "Payment added.");
            //else
            //    return await Result<Guid>.FailureAsync("Error adding payment.");
        }


    }

}
