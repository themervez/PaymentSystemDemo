namespace PaymentSystemDemo.PaymentDesign
{
    public interface IPayment
    {
        bool ProcessPayment(decimal amount, string cardNumber);
    }
}
