using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using EnginDotNet.Models;

namespace EnginDotNet.Controllers
{
    public class AlprController : ApiController
    {
        public IHttpActionResult Post([FromBody]Request request)
        {
            var asm = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName(asm.Location);

            using (var temp = new TempFileCollection(path, false))
            {
                var file = temp.AddExtension("jpg");
                File.WriteAllBytes(file, Convert.FromBase64String(request.Base64Image));

                try
                {
                    var results = OpenAlprHelper.Recognize(file, "gb");

                    if (results == null || !results.Plates.Any())
                    {
                        return NotFound();
                    }

                    var model = new Result
                    {
                        Registration = results.Plates[0].TopNPlates[0].Characters,
                        Confidence = results.Plates[0].TopNPlates[0].OverallConfidence
                    };

                    return Ok(model);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}