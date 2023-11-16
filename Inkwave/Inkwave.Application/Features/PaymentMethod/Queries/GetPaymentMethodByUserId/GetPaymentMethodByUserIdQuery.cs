namespace Inkwave.Application.Features.PaymentMethod.Queries.GetPaymentMethodByUserId
{
    public class GetPaymentMethodByUserIdQuery : IRequest<Result<List<GetPaymentMethodByUserIdDto>>>
    {
        public Guid UserId { get; set; }
        
    }
   
}
