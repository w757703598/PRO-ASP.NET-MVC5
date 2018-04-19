using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第六章.Models;

namespace 第六章.Controllers
{
    public class TestHomeController : Controller
    {
        private IValueCalculator calc;
        private Products[] products =
        {
            new Products {Name="wql",Category="ww",Price=21 },
            new Products {Name="wql",Category="ww",Price=21 },
            new Products {Name="wql",Category="ww",Price=21 }
        };
        public TestHomeController(IValueCalculator calcParam ,IValueCalculator calcParam2)
        {
            calc = calcParam;
        }
        // GET: TestHome
        public ActionResult Index()
        {
            #region Ninject
            //IKernel ninjectkernel = new StandardKernel();//创建ninject内核实例负责解析依赖项并创建新的对象
            ////配置Ninjec内核
            //ninjectkernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //IValueCalculator calc = new LinqValueCalculator();
            #endregion

            ShoopingCart cart = new ShoopingCart(calc) { Products = products };
            decimal totalvalue = cart.CalculateProductTotal();
            return View(totalvalue);
        }
    }
}