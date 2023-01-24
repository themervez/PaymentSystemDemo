using PaymentSystemDemo.DAL.Entities;
using System.Collections.Generic;

namespace PaymentSystemDemo.Repository
{
    public interface IPaymentRepository
    {
        void AddPayment(Payment payment);
        List<Payment> GetAllPayments();
    }
}
