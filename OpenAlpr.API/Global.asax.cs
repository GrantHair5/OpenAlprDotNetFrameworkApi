using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace OpenALPR_MVC_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); //I AM THE 2nd
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}