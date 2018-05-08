using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository repository;
        public IOrderProcessor orderProcessor;
        public CartController(IProductsRepository repo,IOrderProcessor proc )
        {
            repository = repo;
            orderProcessor = proc;
        }
        public ViewResult Index(Cart cart, string returnUrl )
        {
            //return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
        public RedirectToRouteResult AddToCart( Cart cart,int productId,string returnUrl )
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFormCart(Cart cart,int productId,string returnUrl )
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart )
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart,ShippingDetails shippingDetails )
        {
            if (cart.Line.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry,you cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        #region 已经在global依靠模型绑定器为控制器提供cart对象
        //利用session会话状态将一个用户的多个请求关联起来。
        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
        #endregion

    }
}