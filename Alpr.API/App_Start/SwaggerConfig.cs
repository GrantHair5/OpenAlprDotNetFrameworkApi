using System.Web.Http;
using WebActivatorEx;
using EnginDotNet;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace EnginDotNet
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "EnginDotNet");
                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}