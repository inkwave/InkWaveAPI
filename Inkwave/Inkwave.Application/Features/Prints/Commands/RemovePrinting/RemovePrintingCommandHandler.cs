using Inkwave.Application.Interfaces.Repositories;

namespace Inkwave.Application.Features.Prints.Commands.RemovePrinting;

public class RemovePrintingCommandHandler : IRequestHandler<RemovePrintingCommand, Result<bool>>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderRepository _orderRepository;

    public RemovePrintingCommandHandler(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
    {
        _paymentRepository = paymentRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Result<bool>> Handle(RemovePrintingCommand command, CancellationToken cancellationToken)
    {
        return default;
        //var order = await _orderRepository.GetOrderById(command.OrderId);
        //if (order == null)
        //    return await Result<Guid>.FailureAsync("Order not found.");

        //var payment = await _paymentRepository.CreatePaymentAsync(command.OrderId, command.PaymentValue, command.PaymentType, command.PaymentMethod);
        //if (payment == null)
        //    return await Result<Guid>.FailureAsync("Error creating payment.");

        //order.RemovePayment(payment);
        //var result = await _orderRepository.UpdateOrderAsync(order);
        //if (result)
        //    return await Result<Guid>.SuccessAsync(command.OrderId, "Payment Removeed.");
        //else
        //    return await Result<Guid>.FailureAsync("Error Removeing payment.");
    }


}
