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

        public List<Product> ListarProduct()//string name)
        {
            //var product = dProduct.ListarProduct();
            //var result = product.Where(x => x.name == name).ToList();

            return dProduct.ListarProduct();
        }

    }

}
