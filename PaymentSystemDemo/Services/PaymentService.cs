using PaymentSystemDemo.DAL.Entities;
using PaymentSystemDemo.PaymentDesign;
using PaymentSystemDemo.Models;
using PaymentSystemDemo.Repository;
using Microsoft.Extensions.Options;
using System;

namespace PaymentSystemDemo.Services
{
    public class PaymentService : IPaymentService
    {
        //DI
        private readonly PaymentFactoryDP _paymentFactory;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOptionsSnapshot<PaymentProvider> _options;//To access the configuration options

        public PaymentService(PaymentFactoryDP paymentFactory, IPaymentRepository paymentRepository, IOptionsSnapshot<PaymentProvider> options)
        {
            _paymentFactory = paymentFactory;
            _paymentRepository = paymentRepository;
            _options = options;
        }
        //ProcessPayment method that uses the factory design pattern to create the appropriate payment system and processes the payment
        public bool ProcessPayment(string paymentType, decimal amount, string cardNumber)
        {
            var paysystem = _paymentFactory.CreatePaymentSystem(paymentType, _options);
            bool isSuccess = paysystem.ProcessPayment(amount, cardNumber);

            if (isSuccess)//If the payment is successful,it creates a new Payment object with the details of the payment and stores it in the repository
            {
                Payment payment = new Payment
                {
                    Date = DateTime.Now,
                    Amount = amount,
                    PaymentType = paymentType,
                    CardNumber = cardNumber
                };

                _paymentRepository.AddPayment(payment);
            }
            return isSuccess;
        }
    }
}
