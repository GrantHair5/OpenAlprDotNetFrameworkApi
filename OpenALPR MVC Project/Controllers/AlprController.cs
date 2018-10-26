using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.Http;
using OpenALPR_MVC_Project.Models;

namespace OpenALPR_MVC_Project.Controllers
{
    public class AlprController : ApiController
    {
        public RegPlateVm Post([FromBody]Request request)
        {
            using (var temp = new TempFileCollection("C:\\Users\\e0058369\\Desktop\\OpenAlprDotNetFrameworkApi\\", false))
            {
                var file = temp.AddExtension("jpg");
                File.WriteAllBytes(file, Convert.FromBase64String(request.Image));

                var results = OpenALPRHelper.Recognize(file, "gb");

                var model = new RegPlateVm { Reg = results.Plates[0].TopNPlates[0].Characters };

                return model;
            }
        }
    }
}