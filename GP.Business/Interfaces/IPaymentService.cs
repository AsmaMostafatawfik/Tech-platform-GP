using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPayment(
             string cardNumber,
             string expMonth,
             string expYear,
             string cvc,
             decimal amount,
             string currency);
    }

    public class PaymentResult
    {
        public string Status { get; set; }
        public string ChargeId { get; set; }
        public string FailureMessage { get; set; }
    }

}
