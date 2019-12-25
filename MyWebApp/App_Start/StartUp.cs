using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using AutoMapper;

[assembly: OwinStartup(typeof(MyWebApp.App_Start.StartUp))]

namespace MyWebApp.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }


        
    }
}
