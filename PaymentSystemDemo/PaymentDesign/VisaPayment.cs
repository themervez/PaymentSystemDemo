using PaymentSystemDemo.Models;
using Microsoft.Extensions.Options;

namespace PaymentSystemDemo.PaymentDesign
{
    public class VisaPayment : BasePayment
    {
        public VisaPayment(IOptionsSnapshot<PaymentProvider> payp) : base(payp.Get("visa").ApiUrl, payp.Get("visa").ApiKey)
        {
        }
        public override bool ProcessPayment(decimal amount, string cardNumber)
        {
            var payment = new
            {
                amount = amount,
                card_number = cardNumber
            };

            return SendPaymentRequest(payment);
        }
    }
}
