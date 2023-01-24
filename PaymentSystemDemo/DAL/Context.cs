using static PaymentSystemDemo.DAL.Context;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using PaymentSystemDemo.DAL.Entities;

namespace PaymentSystemDemo.DAL
{

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; }

    }

}
