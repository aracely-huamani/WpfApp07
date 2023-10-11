using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DProduct
    {
        public string connectionString = "Data Source=LAB1504-21\\SQLEXPRESS;Initial Catalog=FacturDB;User ID=tecsup;Password=T3csup3168";

        public List<Product> Get()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ListProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                productId = reader.GetInt32(0),
                                name = reader.GetString(1),
                                price = reader.GetDecimal(2),
                                stock = reader.GetInt32(3),
                                active = reader.GetBoolean(4)
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
