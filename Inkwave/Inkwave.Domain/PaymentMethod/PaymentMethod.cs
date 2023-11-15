using Inkwave.Domain.Common;

namespace Inkwave.Domain.PaymentMethod
{
    public class PaymentMethod : BaseAuditableEntity
    {
        public PaymentMethod() 
        {
            Id = Guid.NewGuid();
        }
        public string CardName { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string CardMonth { get; set; } = "";
        public string CardYear { get; set; } = "";
        public string CardCVV { get; set; } = "";

    }
}
