namespace Inkwave.Application.Features.Payments.Commands.AddPayment
{
    public class AddPaymentCommand : IRequest<Result<Guid>>
    {
        public Guid OrderId { get; set; }
        public double PaymentValue { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
