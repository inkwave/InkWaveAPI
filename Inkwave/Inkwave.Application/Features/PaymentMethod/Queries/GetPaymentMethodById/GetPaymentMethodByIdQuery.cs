﻿namespace Inkwave.Application.Features.PaymentMethods.Queries.GetPaymentMethodById
{
    public class GetPaymentMethodByIdQuery : IRequest<Result<GetPaymentMethodByIdDto>>
    {
        public Guid Id { get; set; }

    }

}
