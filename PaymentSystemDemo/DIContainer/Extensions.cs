using Microsoft.Extensions.DependencyInjection;
using PaymentSystemDemo.PaymentDesign;
using PaymentSystemDemo.Repository;
using PaymentSystemDemo.Services;

namespace PaymentSystemDemo.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            // Add PaymentRepository
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            // Add PaymentService
            services.AddScoped<IPaymentService, PaymentService>();

            // Add PaymentFactoryDP
            services.AddScoped<PaymentFactoryDP>();

            // Add Payment Options
            services.AddScoped<MasterCardPayment>();
            services.AddScoped<PayPalPayment>();
            services.AddScoped<VisaPayment>();
        }
    }
}