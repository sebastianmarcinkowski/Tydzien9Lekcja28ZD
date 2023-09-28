using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceManager.Models.Domains;
using InvoiceManager.Models.Repositories;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ProductRepository _productRepository = new ProductRepository();
        public ActionResult Index()
        {
            var products = _productRepository.GetProducts();

            return View(products);
        }

        public ActionResult Product(int id = 0)
        {
            var product =
                id == 0
                    ? new Product()
                    : _productRepository.GetProduct(id);

            ViewBag.Title =
                id == 0
                    ? "Dodawanie nowego produktu"
                    : "Edycja produktu";

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Product(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title =
                    product.Id == 0
                        ? "Dodawanie nowego produktu"
                        : "Edycja produktu";

                return View("Product", product);
            }

            if (product.Id == 0)
                _productRepository.Add(product);
            else
                _productRepository.Update(product);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _productRepository.Delete(id);
            }
            catch (Exception exception)
            {
                // Logowanie.
                return Json(new { Success = false, Message = exception.Message });
            }

            return Json(new { Success = true });
        }
    }
}