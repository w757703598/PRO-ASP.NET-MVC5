using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 第六章.Models;

namespace EssentialTools
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void Discount_Above_100()
        {
            //准备
            IDiscountHelper target = getTestObject();
            decimal total = 200;
            //动作
            var discountedTotal = target.ApplyDiscount(total);
            //断言
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }
        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            //准备
            IDiscountHelper target = getTestObject();
            //动作
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);
            //断言
            Assert.AreEqual(5, TenDollarDiscount,"10 discount iswrong");
            Assert.AreEqual(95, HundredDollarDiscount, "100 discount iswrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "50 discount iswrong");
        }
    }
}
