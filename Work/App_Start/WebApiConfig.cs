using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Work
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // http://www.abc.com/api/User/Verify/anil

            // http://www.abc.com/api/User/ppp
            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "blog",
            //    routeTemplate: "api/Blog/{title}{id}",
            //    defaults: new { Controllers = "Blog", action = "index" }
            //);

            config.Routes.MapHttpRoute(
                name: "FileApi",
                routeTemplate: "api/{controller}/{action}/{id}"               
            );
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            EnableCorsAttribute attribtue = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(attribtue);
        }
    }
}
