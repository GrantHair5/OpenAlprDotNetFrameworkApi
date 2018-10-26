using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Web.Http;
using OpenAlprDotNetFrameworkApi.Models;

namespace OpenAlprDotNetFrameworkApi.Controllers
{
    public class AlprController : ApiController
    {
        public RegPlateVm Post([FromBody]Request request)
        {
            var asm = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName(asm.Location);

            using (var temp = new TempFileCollection(path, false))
            {
                var file = temp.AddExtension("jpg");
                File.WriteAllBytes(file, Convert.FromBase64String(request.Base64Image));

                var results = OpenALPRHelper.Recognize(file, "gb");

                var model = new RegPlateVm { Registration = results.Plates[0].TopNPlates[0].Characters };

                return model;
            }
        }
    }
}