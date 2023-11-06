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
        private string connection = "Data Source=DESKTOP-90DN5US\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=tecsup;Password=T3csup3168";

        public void InsertarProduct(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand("InsertarProduct", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@product_id", product.productId);
                    command.Parameters.AddWithValue("@name", product.name);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@descripcion", product.descripcion);
                    command.Parameters.AddWithValue("@active", product.active);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProduct(int product)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                using (SqlCommand command = new SqlCommand("EliminarProduct", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@productId", product);

                    command.ExecuteNonQuery();
                }


            }


        }


        public List<Product> Get()
        {
            List<Product> result = new List<Product>();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand("ListarProduct", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.productId = Convert.ToInt32(reader["product_id"]);
                        product.name = reader["name"].ToString();
                        product.descripcion = reader["descripcion"].ToString();
                        product.price = Convert.ToDecimal(reader["price"]);
                        product.stock = Convert.ToInt32(reader["stock"]);
                        product.active = Convert.ToBoolean(reader["active"]);

                        result.Add(product);
                    }
                    reader.Close();
                }
            }
            return result;
        }
    }
}
