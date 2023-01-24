using PaymentSystemDemo.Models;
using Microsoft.Extensions.Options;


namespace PaymentSystemDemo.PaymentDesign
{
    public class PaymentFactoryDP
    {
        //CreatePaymentSystem method is used to create different payment systems based on the paymentType passed as parameter
        public IPayment CreatePaymentSystem(string paymentType, IOptionsSnapshot<PaymentProvider> options)
        {
            IPayment paysystem = null;

            switch (paymentType.ToLower())
            {
                case "visa"://If paymentType is visa, it creates an instance of VisaPayment class
                    paysystem = new VisaPayment(options);
                    break;
                case "mastercard":
                    paysystem = new MasterCardPayment(options);
                    break;
                case "paypal":
                    paysystem = new PayPalPayment(options);
                    break;
            }
            return paysystem;
        }
    }
}
