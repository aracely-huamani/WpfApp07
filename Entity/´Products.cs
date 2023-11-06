using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {

        public int productId { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public int stock { get; set; }
        public bool active { get; set; }

        public string descripcion { get; set; }
    }
}
