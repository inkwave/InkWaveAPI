using Inkwave.Application.Features.Payments.Queries.GetAllPayments;

namespace Inkwave.Application.Features.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<PaymentResponse> 
    {
      
        public GetPaymentByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }



    }
}
