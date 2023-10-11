using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BProduct
    {
        public string connectionString = "Data Source=LAB1504-21\\SQLEXPRESS;Initial Catalog=FacturDB;User ID=tecsup;Password=T3csup3168";

        public static List<Product> GetByName(string Name)

        {
            DProduct data = new DProduct();
            List <Product> result = new List<Product>();
            
            var products = data.Get();

            foreach (var product in products)
            {
                if (product.name == Name)
                {
                    result.Add(product);
                }
            }
        }
    }
}
