namespace Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodByUserId
{
    public class GetPaymentMethodByUserIdDto : IMapFrom<PaymentMethod>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CardName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CardMonth { get; set; } = string.Empty;
        public string CardYear { get; set; } = string.Empty;
        public string CardCVV { get; set; } = string.Empty;
    }
}