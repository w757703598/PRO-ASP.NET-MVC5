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
    public class UnitTest4
    {
        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            //准备-创建一个模仿的订单处理器
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            //创建一个购物车
            Cart cart = new Cart();
            //准备-创建一个控制器
            ShippingDetails shippingdetail = new ShippingDetails();
            CartController target = new CartController(null,mock.Object);
            //动作
            ViewResult result = target.Checkout(cart, shippingdetail);
            //断言--检查-订单尚未传递给处理器
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            //断言--检查该方法返回的是默认视图
            Assert.AreEqual("", result.ViewName);
            //Assert-check that I am Passing an invalid model to the view 
            //断言--检查，给视图传递的是一个非法模型
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }
    }
}
