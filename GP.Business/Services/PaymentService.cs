using GP.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Business.Services
{
    public class PaymentService:IPaymentService
    {
        private readonly string _secretKey;

        public PaymentService(IConfiguration configuration)
        {
            _secretKey = configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _secretKey;
        }

        public async Task<PaymentResult> ProcessPayment(
            string cardNumber,
            string expMonth,
            string expYear,
            string cvc,
            decimal amount,
            string currency)
        {
            try
            {
                // Create payment token
                var tokenOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = expMonth,
                        ExpYear = expYear,
                        Cvc = cvc
                    }
                };

                var tokenService = new TokenService();
                var token = await tokenService.CreateAsync(tokenOptions);

                // Create charge
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = (long)(amount * 100),
                    Currency = currency,
                    Source = token.Id,
                    Description = "Ecommerce payment"
                };

                var chargeService = new ChargeService();
                var charge = await chargeService.CreateAsync(chargeOptions);

                return new PaymentResult
                {
                    Status = charge.Status,
                    ChargeId = charge.Id,
                    FailureMessage = charge.FailureMessage
                };
            }
            catch (StripeException ex)
            {
                return new PaymentResult
                {
                    Status = "failed",
                    FailureMessage = ex.Message
                };
            }
        }
    }
}
