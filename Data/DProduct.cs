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
        private string connection = "Data Source=LAB1504-21\\SQLEXPRESS;Initial Catalog=FacturDB;User ID=tecsup;Password=T3csup3168";

        public void InsertarProduct(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("SET IDENTITY_INSERT products ON", sqlConnection);
                command.ExecuteNonQuery();

                command = new SqlCommand("InsertarProducts", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@productId", product.productId);
                command.Parameters.AddWithValue("@name", product.name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@stock", product.stock);
                command.Parameters.AddWithValue("@active", product.active);

                command.ExecuteNonQuery();

                command = new SqlCommand("SET IDENTITY_INSERT products OFF", sqlConnection);
                command.ExecuteNonQuery();
            }
        }

        public List<Product> ListarProduct()
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
                        product.productId = Convert.ToInt32(reader["productId"]);
                        product.name = reader["name"].ToString();
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
