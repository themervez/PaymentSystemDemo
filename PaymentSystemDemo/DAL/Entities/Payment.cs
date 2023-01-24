using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystemDemo.DAL.Entities
{
    public class Payment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string PaymentType { get; set; }

        [Required]
        [MaxLength(50)]
        public string CardNumber { get; set; }
    }
}
