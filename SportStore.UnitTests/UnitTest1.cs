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
    public class UnitTest1
    {

        [TestMethod]
        public void Can_Paginate()
        {
            //准备
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(u => u.Products).Returns(new Product[] {
                new Product {ProductID=1,Name="p1" },
                new Product {ProductID=2,Name="p2" },
                new Product {ProductID=3,Name="p3" },
                new Product {ProductID=4,Name="p4" },
                new Product {ProductID=5,Name="p5" },
                //new Product {ProductID=6,Name="p6" }
            });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;

            //动作
            PruductsListViewModel result =(PruductsListViewModel) controller.List(null,2).Model;

            //断言
            Product[] productArray = result.Products.ToArray();
            Assert.IsTrue(productArray.Length == 2);
            Assert.AreEqual(productArray[0].Name, "p4");
            Assert.AreEqual(productArray[1].Name, "p5");

        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //准备-定义一个HTML辅助器。目的是运用扩展方法
            HtmlHelper myhelper = null;
            //准备-创建PageingInfo数据
            PagingInfo pageinfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            //准备-用lambda表达式建立委托
            Func<int, string> PageUrlDelegate = i => "Page" + i;
            //动作
            MvcHtmlString result = myhelper.PageLinks(pageinfo, PageUrlDelegate);
            //断言
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a><a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a><a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
;        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                                new Product                {ProductID=1,Name="p1" },
                new Product {ProductID=2,Name="p2" },
                new Product {ProductID=3,Name="p3" },
                new Product {ProductID=4,Name="p4" },
                new Product {ProductID=5,Name="p5" },
            });
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;
            //动作
            PruductsListViewModel result = (PruductsListViewModel)controller.List(null,2).Model;
            //断言
            PagingInfo pageinfo = result.PageingInfo;
            Assert.AreEqual(pageinfo.CurrentPage, 2);
            Assert.AreEqual(pageinfo.ItemsPerPage, 3);
            Assert.AreEqual(pageinfo.TotalItems, 5);
            Assert.AreEqual(pageinfo.TotalPages, 2);
        }
        [TestMethod]
        public void Can_Create_Categories()
        {
            //准备-创建模拟存储库
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(p => p.Products).Returns(new Product[]
            {
                new Product {ProductID=1,Name="p1" ,Category="Apples"},
                new Product {ProductID=2,Name="p2",Category="Plums" },
                new Product {ProductID=3,Name="p3",Category="Apples" },
                new Product {ProductID=4,Name="p4",Category="Yellow" },
                new Product {ProductID=5,Name="p5",Category="Apples" },
            });
            //准备创建控制器
            NavController controller = new NavController(mock.Object);
            //动作获取集合
            string[] result = ((IEnumerable<string>)controller.Menu().Model).ToArray();
            //断言
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], "Apples");
            Assert.AreEqual(result[1], "Plums");
            Assert.AreEqual(result[2], "Yellow");
        }
        [TestMethod]
        public void Indicates_Selected_Category()
        {
            //准备-创建模拟存储库
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(p => p.Products).Returns(new Product[]
            {
                new Product {ProductID=1,Name="p1" ,Category="Apples"},
                new Product {ProductID=2,Name="p2",Category="Plums" },
                new Product {ProductID=3,Name="p3",Category="Apples" },
                new Product {ProductID=4,Name="p4",Category="Yellow" },
                new Product {ProductID=5,Name="p5",Category="Apples" },
            });
            //准备创建控制器
            NavController controller = new NavController(mock.Object);
            //准备-定义已选分类
            string category = "Apples";
            //动作
            string result = controller.Menu(category).ViewBag.SelectedCategory;
            //断言
            Assert.AreEqual(category, result);
        }
    }
}
