using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportStore.Domain.Entities;
using System.Linq;

namespace SportStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            //准备一些测试产品
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Product p2 = new Product { ProductID = 2, Name = "p2" };
            Product p3 = new Product { ProductID = 3, Name = "p3" };

            //准备-创建一个新的购物车
            Cart target = new Cart();
            //动作
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);
            CartLine[] result = target.Line.ToArray();

            //断言
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Product, p1);
        }
        //添加数量测试
        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //准备一些测试产品
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Product p2 = new Product { ProductID = 2, Name = "p2" };
            Product p3 = new Product { ProductID = 3, Name = "p3" };

            //准备-创建一个新的购物车
            Cart target = new Cart();
            //动作
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);
            target.AddItem(p1, 10);
            CartLine[] result = target.Line.ToArray();
            //断言
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Quantity, 11);
            Assert.AreEqual(result[1].Quantity, 2);
        }
        [TestMethod]
        //删除产品测试
        public void Can_Remove_Line()
        {
            //准备一些测试产品
            Product p1 = new Product { ProductID = 1, Name = "p1" };
            Product p2 = new Product { ProductID = 2, Name = "p2" };
            Product p3 = new Product { ProductID = 3, Name = "p3" };

            //准备-创建一个新的购物车
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);
            target.AddItem(p1, 10);

            //动作
            target.RemoveLine(p2);
            //断言
            Assert.AreEqual(target.Line.Where(c => c.Product == p2).Count(), 0);
            Assert.AreEqual(target.Line.Count(), 1);
        }
        //计算总价格
        [TestMethod]
        public void Can_Calculate_Cart_Total()
        {
            //准备一些测试产品
            Product p1 = new Product { ProductID = 1, Name = "p1" ,Price=100M};
            Product p2 = new Product { ProductID = 2, Name = "p2" ,Price=50M};
            Product p3 = new Product { ProductID = 3, Name = "p3" };

            //准备-创建一个新的购物车
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);
            target.AddItem(p1, 10);

            //动作
            var totalPrice= target.ComputeTotalValue();
            //断言
            Assert.AreEqual(totalPrice, 1200M);
        }
        //清空购物车
        [TestMethod]
        public void Can_Clear_Contents()
        {
            //准备一些测试产品
            Product p1 = new Product { ProductID = 1, Name = "p1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "p2", Price = 50M };
            Product p3 = new Product { ProductID = 3, Name = "p3" };

            //准备-创建一个新的购物车
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);
            target.AddItem(p1, 10);
            //动作
            target.Clear();
            //断言
            Assert.AreEqual(target.Line.Count(), 0);
        }
    }
}
