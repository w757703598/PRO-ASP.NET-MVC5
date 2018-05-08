using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductsRepository repository;
        public AdminController(IProductsRepository repo )
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId )
        {
            Product product = repository.Products.FirstOrDefault(u => productId == u.ProductID);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product ,HttpPostedFileBase image=null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMineType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productId )
        {
            Product deletedproduct = repository.DeleteProduct(productId);
            if (deletedproduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedproduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}