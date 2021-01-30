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
    // [ViewResultDetails]
    // [MyResult]
     [RangeException]


    [TypeFilter(typeof(DiagnosticsFilter))]
    //[TypeFilter(typeof(TimeFilter))]
    [ServiceFilter(typeof(TimeFilter))]
    public class HomeController : Controller
    {
        // [Profile] // my own attribute-filter (from Infrastructure)
        public IActionResult Index()
        { 
            return View("Index", "This is simple Index page");
        }

        public IActionResult Dict() => View("Index", new Dictionary<string, string>() { 
            ["Key 1"] = "Value 1",
            ["Key 2"] = "Value 2",
            ["Key 3"] = "Value 3"
        });

        public IActionResult GenerateException(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();
            else if (id > 10)
                throw new ArgumentOutOfRangeException();
            else
                return View("Index", $"The value is {id}");
        }
    }
}
