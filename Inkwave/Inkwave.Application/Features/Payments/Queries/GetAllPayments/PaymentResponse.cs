namespace Inkwave.Application.Features.Payments.Queries.GetAllPayments
{
    public class PaymentResponse : IMapFrom<Payment> 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
    }
}