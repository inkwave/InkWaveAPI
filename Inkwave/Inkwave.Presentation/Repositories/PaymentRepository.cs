using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Payment;
using Inkwave.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inkwave.Persistence.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        public PaymentRepository() { }

        public Task<Payment> CreatePaymentAsync(Guid orderId, double paymentValue, string paymentType, string paymentMethod)
        {
           var payment = Payment.Create(orderId, paymentValue, paymentType, paymentMethod);
            return Task.FromResult(payment);

        }

        

        






    }
}
