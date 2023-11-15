namespace Inkwave.Application.Features.PaymentMethod.Commands.AddPaymentMethod
{
    public class AddPaymentMethodCommand : IRequest<Result<Guid>>
    {

        public Guid Id { get; set; }

        public string CardName { get; set; } = "";

        public string CardNumber { get; set; } = "";

        public string CardMonth { get; set; } = "";
        public string CardYear { get; set; } = "";

        public string CardCVV { get; set; } = "";

    }
}
