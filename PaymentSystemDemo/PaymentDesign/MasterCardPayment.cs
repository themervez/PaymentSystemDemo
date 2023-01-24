using PaymentSystemDemo.Models;
using Microsoft.Extensions.Options;

namespace PaymentSystemDemo.PaymentDesign
{
    public class MasterCardPayment : BasePayment
    {
        //Constructor
        public MasterCardPayment(IOptionsSnapshot<PaymentProvider> payp) : base(payp.Get("mastercard").ApiUrl, payp.Get("mastercard").ApiKey)//IOptionsSnapshot<PaymentProvider> is a configuration object that holds the values for different payment providers, such as their ApiUrl and ApiKey
        {
        }
        public override bool ProcessPayment(decimal amount, string cardNumber)
        {
            var payment = new
            {
                amount = amount,
                card_number = cardNumber
            };

            return SendPaymentRequest(payment);//making a post request to the api with the payment object
        }
    }
}
