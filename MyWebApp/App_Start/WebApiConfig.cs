using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Business;
using AutoMapper;

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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static AutofacWebApiDependencyResolver ConfigService()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperBusinessProfile>();
            });
            builder.Register(x => new Mapper(mapperConfig)).As<IMapper>();
            builder.RegisterModule<UnitAutofacConfig>();

            builder.RegisterType<ProductService>().AsImplementedInterfaces();
            builder.RegisterType<OrderService>().AsImplementedInterfaces();

            

            var container = builder.Build();
            
            AutofacWebApiDependencyResolver autofacWebApiDependencyResolver = new AutofacWebApiDependencyResolver(container);

            return autofacWebApiDependencyResolver;
        }
    }
}
