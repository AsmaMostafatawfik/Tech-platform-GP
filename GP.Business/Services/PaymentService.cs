using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class PaymentService
    {
        private readonly string _secretKey;
        public PaymentService(string secretKey)
        {
            _secretKey = secretKey;
            StripeConfiguration.ApiKey = secretKey;
        }
        public async Task<string> ProcessPayment(string cardNumber,string expMonth, string expYear,string cvc,decimal amount,string currency)
        {
            try
            {
                var TokenService = new TokenService();
                var TokenOption = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        Cvc = cvc,
                        Currency = currency,
                        ExpMonth=expMonth,
                        ExpYear=expYear
                    }
                };
                var token = await TokenService.CreateAsync(TokenOption);
                var chargeService = new ChargeService();
                var chargeOption = new ChargeCreateOptions
                {
                    Amount = (long)(amount * 100),
                    Currency = currency,
                    Source = token.Id,
                    Description="MVC Stripe Payment"
                };
                var charge = await chargeService.CreateAsync(chargeOption);
                return charge.Status;
            }
            catch(StripeException ex)
            {
                return ex.Message;
            }
        }
    }
}
