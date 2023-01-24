using PaymentSystemDemo.DAL;
using PaymentSystemDemo.DAL.Entities;
using PaymentSystemDemo.PaymentDesign;
using System.Collections.Generic;
using System.Linq;

namespace PaymentSystemDemo.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly Context _context;
        public PaymentRepository(Context context)
        {
            _context = context;
        }
        public void AddPayment(Payment payment)//Add a new payment to the database.
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }
    }
}
