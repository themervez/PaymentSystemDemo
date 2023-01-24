using PaymentSystemDemo.Models;
using Microsoft.Extensions.Options;


namespace PaymentSystemDemo.PaymentDesign
{
    public class PayPalPayment : BasePayment//Implemented BasePayment
    {
        public PayPalPayment(IOptionsSnapshot<PaymentProvider> payp) : base(payp.Get("paypal").ApiUrl, payp.Get("paypal").ApiKey)
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
