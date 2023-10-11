using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Invoice
    {
        [Key]
        public int invoiceId { get; set; }

        public int customerId { get; set; }

        public DateTime date { get; set; }

        public decimal total { get; set; }

        public bool active { get; set; }

        [ForeignKey("customerId")]
        public Customer Customers { get; set; }
    }
}
