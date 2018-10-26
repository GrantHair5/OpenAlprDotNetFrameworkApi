using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Web.Http;
using OpenAlprDotNetFrameworkApi.Models;

namespace OpenAlprDotNetFrameworkApi.Controllers
{
    public class AlprController : ApiController
    {
        public RegPlateVm Post([FromBody]Request request)
        {
            using (var temp = new TempFileCollection("C:\\Users\\e0058369\\Desktop\\OpenAlprDotNetFrameworkApi\\", false))
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