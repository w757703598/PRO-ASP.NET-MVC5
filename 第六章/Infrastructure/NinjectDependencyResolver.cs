using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using 第六章.Models;
using Ninject.Web.Common;

namespace 第六章.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernekParam )
        {
            kernel = kernekParam;
            AddBindings();
        }
        public object GetService( Type serviceType )
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices( Type serviceType )
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //InRequsestScope一个请求创建一个作用域。获取独立的对象，单同一个请求的多个依赖项将会使用这个类的单一实例s进行解析
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            //绑定属性值和构造器参数值WithPropertyValue("DisCountSize",50m)
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountPara", 10m);
            //条件绑定
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountPara", 10m);
            //当创建linqvalueCalculate对象的时候flexibleDiscounhelper作为Idiscounthelper接口的实现
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();


        }
    }
}