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

            var data = File.ReadAllBytes(request.ImageUrl);

            using (var image = Image.FromStream(new MemoryStream(data)))
            {
                image.Save("output.png", ImageFormat.Png);  // Or Png
            }

            var results = OpenALPRHelper.Recognize(request.ImageUrl, "gb");

            var model = new RegPlateVm { Reg = results.Plates[0].TopNPlates[0].Characters };

            return model;
        }
    }
}