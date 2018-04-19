using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using 第六章.Models;
using System.Linq;

namespace EssentialTools
{
    [TestClass]
    public class UnitTest2
    {
        private Products[] products =
{
            new Products {Name="wql",Category="ww",Price=21 },
            new Products {Name="wql",Category="ww",Price=21 },
            new Products {Name="wql",Category="ww",Price=21 }
        };
        [TestMethod]
        public void Sum_Products_Correctly()
        {
            //准备
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);
            //动作
            var result = target.ValueProducts(products);
            //断言
            Assert.AreEqual(products.Sum(e => e.Price), result);

        }
    }
}
