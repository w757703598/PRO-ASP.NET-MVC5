using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportStore.WebUI.Models;
using SportStore.WebUI.HtmlHelpers;


namespace SportStore.UnitTests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            //准备-创建模仿存储库
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Name="p1",ProductID=1,Category="Apples" }

            }.AsQueryable());
            //准备-创建cart
            Cart cart = new Cart();
            //准备-创建控制器
            CartController target = new CartController(mock.Object,null);
            //动作-对CART添加一个产品
            target.AddToCart(cart, 1, null);
            //断言
            Assert.AreEqual(cart.Line.Count(), 1);
            Assert.AreEqual(cart.Line.ToArray()[0].Product.ProductID, 1);
        }
        [TestMethod]
        public void Adding_Product_To_Cart_Goed_To_Cart_Screen()
        {
            //准备-创建模仿存储库
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {Name="p1",ProductID=1,Category="Apples" }

            }.AsQueryable());
            //准备-创建cart
            Cart cart = new Cart();
            //准备-创建控制器
            CartController target = new CartController(mock.Object,null);
            //动作-对CART添加一个产品
            RedirectToRouteResult result= target.AddToCart(cart, 2, "myUrl");
            //断言
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }
        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            //准备-创建cart
            Cart cart = new Cart();
            //准备--创建控制器
            CartController target = new CartController(null,null);
            //动作--调用Index方法
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;
            //断言
            Assert.AreEqual(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
       
                }
    }
}
