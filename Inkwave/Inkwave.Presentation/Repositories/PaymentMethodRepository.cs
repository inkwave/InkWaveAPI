using Inkwave.Application.Interfaces.Repositories;
using Inkwave.Domain.Payment;
using Inkwave.Domain.PaymentMethod;
using Inkwave.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inkwave.Persistence.Repositories
{
    internal class PaymentMethodRepository : IPaymentMethodRepository
    {


        readonly IGenericRepository<PaymentMethod> genericRepository;
        public PaymentMethodRepository(IGenericRepository<PaymentMethod> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<PaymentMethod> CreatePaymentMethodAsync(string cardName, string cardNumber, string cardMonth, string cardYear, string cardCVV)
        {
            var model = new PaymentMethod { CardName = cardName, CardNumber = cardNumber, CardMonth = cardMonth, CardYear = cardYear, CardCVV = cardCVV };
            await genericRepository.AddAsync(model);
            return model;

        }

         

        

        






    }
}
