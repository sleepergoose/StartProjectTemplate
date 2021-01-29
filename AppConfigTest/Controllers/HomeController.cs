using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppConfigTest.Infrastructure;

namespace AppConfigTest.Controllers
{
    // [RequireHttps]
    // [HttpsOnly] // This is my own filter defined in Infrastructure
    [ViewResultDetails]
    public class HomeController : Controller
    {
        // [Profile] // my own attribute-filter (from Infrastructure)
        public IActionResult Index()
        { 
            return View("Index", "This is the Index action on the Home Controller");
        }

        public IActionResult Dict() => View("Index", new Dictionary<string, string>() { 
            ["Key 1"] = "Value 1",
            ["Key 2"] = "Value 2",
            ["Key 3"] = "Value 3"
        });
    }
}
