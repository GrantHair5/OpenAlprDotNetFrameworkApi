using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace OpenAlprDotNetFrameworkApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); //I AM THE 2nd
        }
    }
}