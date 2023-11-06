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
        private DProduct dProduct;
        public BProduct()
        {
            dProduct = new DProduct();
        }

        public void InsertarProduct(Entity.Product product)
        {
            dProduct.InsertarProduct(product);
        }

        public void EliminarProduct(int product)
        {
            dProduct.EliminarProduct(product);
        }


        public List<Product> GetByName(string name)
        {
            List<Product> result = new List<Product>();

            var products = dProduct.Get();

            result = products.Where(x => x.name.Contains(name)).ToList();

            return result;
        }

        public Product GetProductById(int productId)
        {
            var products = dProduct.Get();
            return products.FirstOrDefault(p => p.productId == productId);
        }

    }

}
