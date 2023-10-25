using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            BProduct bproduct = new BProduct();
            List<Product> product = bproduct.ListarProduct();

            //Convertir Entidad a modelo

            List<ProductModel> productsModel = product.Select(x => new ProductModel
            {
                Id = x.productId,
                Name = x.name,
                Price = x.price.ToString("0.00"),
            }).ToList();
            return View(productsModel);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(); 
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            try
            {
        
                    BProduct bproduct = new BProduct();

                   
                    Product nuevoProducto = new Product
                    {
                        productId = model.Id,
                        name = model.Name,
                        price = Convert.ToDecimal(model.Price),
                    };

               
                bproduct.InsertarProduct(nuevoProducto);

                
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                // En caso de error, muestra la vista de nuevo o maneja el error de otra manera.
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
