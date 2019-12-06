using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Business;

namespace MyWebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.DependencyResolver = ConfigService();

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional }
            );
        }

        public static AutofacWebApiDependencyResolver ConfigService()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ProductService>().AsImplementedInterfaces();
            builder.RegisterType<OrderService>().AsImplementedInterfaces();

            var container = builder.Build();

            AutofacWebApiDependencyResolver autofacWebApiDependencyResolver = new AutofacWebApiDependencyResolver(container);

            return autofacWebApiDependencyResolver;
        }
    }
}
