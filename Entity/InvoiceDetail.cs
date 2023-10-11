using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InvoiceDetail
    {
        [Key]
        
        public int detailId { get; set; }

        
        public int invoiceId { get; set; }

       
        public int productId { get; set; }

       
        public int quantity { get; set; }

        public decimal price { get; set; }

        public decimal subtotal { get; set; }
        public bool active { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
