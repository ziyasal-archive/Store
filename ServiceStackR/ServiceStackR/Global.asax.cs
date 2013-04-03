using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ServiceStackR.App_Start;
using ServiceStackR.Code;

namespace ServiceStackR
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Initialize your application
            var appHost = new HelloAppHost();
            appHost.Init();
        }
    }
}