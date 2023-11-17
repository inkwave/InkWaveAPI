namespace Inkwave.Application.Features.PaymentMethods.Commands.UpdatePaymentMethod
{
    public class UpdatePaymentMethodCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string CardName { get; set; } = "";

        public string CardNumber { get; set; } = "";

        public string CardMonth { get; set; } = "";
        public string CardYear { get; set; } = "";

        public string CardCVV { get; set; } = "";
    }
}
