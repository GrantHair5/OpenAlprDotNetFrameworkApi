using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using openalprnet;
using OpenALPR.API.Models;

namespace OpenALPR.API.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AlprResultsNet results = OpenALPRHelper.Recognize(@"C:\Users\e0058369\Desktop\OpenAlprMVC\OpenALPR MVC Project\samples\test.jpg");

            var model = new RegPlateVm { Reg = results.Plates[0].TopNPlates[0].Characters };
            return View(model);
        }
    }
}