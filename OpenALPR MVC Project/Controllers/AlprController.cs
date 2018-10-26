using System;
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
            var requestId = Guid.NewGuid();

            var filePath = $"C:\\Users\\e0058369\\Desktop\\OpenAlprDotNetFrameworkApi\\{requestId}.jpg";
            File.WriteAllBytes(filePath, Convert.FromBase64String(request.Image));

            var results = OpenALPRHelper.Recognize(filePath, "gb");

            var model = new RegPlateVm { Reg = results.Plates[0].TopNPlates[0].Characters };

            if (File.Exists($"C:\\Users\\e0058369\\Desktop\\OpenAlprDotNetFrameworkApi\\{requestId}.jpg"))
            {
                File.Delete($"C:\\Users\\e0058369\\Desktop\\OpenAlprDotNetFrameworkApi\\{requestId}.jpg");
            }

            return model;
        }
    }
}