using SportStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.WebUI.Models;
using SportStore.Domain.Entities;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int pageSize = 4;
        public ProductController(IProductsRepository repositoryParam )
        {
            repository = repositoryParam;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category">分类</param>
        /// <param name="page">默认页</param>
        /// <returns></returns>
        public ViewResult List(string category, int page = 1 )
        {
            //return View(repository.Products.OrderBy(p=>p.ProductID).Skip((page-1)*pageSize).Take(pageSize));
            PruductsListViewModel model = new PruductsListViewModel()
            {
                Products = repository.Products.Where(p => category == null || p.Category == category).OrderBy(p => p.ProductID).Skip((page - 1) * pageSize).Take(pageSize),
                PageingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory=category

            };
            return View(model);
        }
        public FileContentResult GetImage(int productId )
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMineType);
            }
            else
            {
                return null;
            }
        }
    }
}