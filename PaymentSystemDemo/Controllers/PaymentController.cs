using PaymentSystemDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace PaymentSystemDemo.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;//DI

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payment(string paymentType, decimal amount, string cardNumber)
        {
            if (ModelState.IsValid)
            {
                if (_paymentService.ProcessPayment(paymentType, amount, cardNumber))
                {
                    ViewBag.Message = "Payment Successful!";
                }
                else
                {
                    ViewBag.Message = "Payment failed. Please check your details and try again.";
                }
            }
            return View();
        }
    }
}
