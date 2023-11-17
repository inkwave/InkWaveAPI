namespace Inkwave.Application.Features.PaymentMethods.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommand : IRequest<Result<Guid>>
    {
        public Guid UserId { get; set; }

        public string CardName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public string CardMonth { get; set; } = string.Empty;
        public string CardYear { get; set; } = string.Empty;

        public string CardCVV { get; set; } = string.Empty;

    }
}
