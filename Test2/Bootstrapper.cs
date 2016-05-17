using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using OrdersApp;
using Test2.Controllers;

namespace Test2
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();  
                      
            container.RegisterType<IOrderManager, OrderManager>();
            container.RegisterType<IOrderContext, OrderContext>();
            container.RegisterType<IController, ProductsController>("Products");

            return container;
        }
    }
}