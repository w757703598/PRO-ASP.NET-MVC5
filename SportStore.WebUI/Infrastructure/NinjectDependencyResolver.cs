using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Ninject.Web.Common;
using Moq;
using SportStore.Domain.Entities;
using SportStore.Domain.Abstract;
using SportStore.Domain.Concreate;

namespace SportStore.WebUI.Infrastructure
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
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product {Name="FootBALL",Price=25 ,Description="Nike"},
            //    new Product {Name="Surf board",Price=179 },
            //    new Product {Name="Running shoes",Price=95 }
            //});
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();


        }
    }
}