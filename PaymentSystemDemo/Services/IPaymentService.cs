
namespace PaymentSystemDemo.Services
{
    public interface IPaymentService
    {
        bool ProcessPayment(string paymentType, decimal amount, string cardNumber);
    }
}
