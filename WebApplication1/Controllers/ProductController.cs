using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            BProduct bproduct = new BProduct();
            List<Product> product = bproduct.GetByName("");

            //Convertir Entidad a modelo

            List<ProductModel> productsModel = product.Select(x => new ProductModel
            {
                Id = x.productId,
                Name = x.name,
                Descripcion = x.descripcion,
                Price = x.price,

            }).ToList();
            return View(productsModel);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
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
                if (ModelState.IsValid)
                {
                    BProduct business = new BProduct();
                    Product product = new Product
                    {
                        productId = model.Id,
                        name = model.Name,
                        price = model.Price,


                    };
                    business.InsertarProduct(product);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
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
        public ActionResult Delete(int product)
        {
            BProduct business = new BProduct();
            Product products = business.GetProductById(product);

            if (products == null)
            {
                return NotFound();
            }

            ProductModel model = new ProductModel
            {
                Id = products.productId,
                Name = products.name,
                Price = products.price,
                Descripcion = products.descripcion,

            };

            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int product, IFormCollection collection)
        {
            try
            {
                BProduct business = new BProduct();
                business.EliminarProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}
