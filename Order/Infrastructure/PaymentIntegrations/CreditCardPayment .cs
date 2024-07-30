using Core.Services;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;

namespace Core.PaymentIntegrations
{
    public class CreditCardPayment : ICreditCardPayment
    {
        public Task<InvoiceDto> PaymentWithCreditCard(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
