using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DemoSecuredAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // add global filters to every request 
            config.Filters.Add(new HttpsRequiredAttribute());       // require HTTPS
            config.Filters.Add(new AuthenticationAttribute());      // if valid token found in the header, authenticate
            config.Filters.Add(new AuthorizeAttribute());           // require that each request have valid credentials, unless marked as [AllowAnonymous]
            config.Filters.Add(new UnhandledExceptionFilter());     // catch any unhandled exceptions and use Elmah to report

            // needed for cross-origin-requests (which means basically all requests)
            var corsSetup = new EnableCorsAttribute("*", "*", "*"); // allow a call from anyone
            config.EnableCors(corsSetup);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
