using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IPaymentService
    {
        Task<string> ProcessPayment(string cardNumber, string expMonth, string expYear, string cvc, decimal amount, string currency);

    }
}
