using System.Web.Http;
using OpenALPR_MVC_Project.Models;

namespace OpenALPR_MVC_Project.Controllers
{
    public class AlprController : ApiController
    {
        public RegPlateVm Post([FromBody]Request request)
        {
            var results = OpenALPRHelper.Recognize($"{request.ImageUrl}");

            var model = new RegPlateVm { Reg = results.Plates[0].TopNPlates[0].Characters };

            return model;
        }
    }
}