using System.Web.Mvc;
using TestTask.Web.Data.IRepositories;
using TestTask.Web.Data.Repositories;
using Unity;
using Unity.Mvc5;

namespace TestTask.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IOrderRepository, OrderRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}