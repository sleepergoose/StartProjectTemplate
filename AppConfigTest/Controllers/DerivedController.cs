using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using AppConfigTest.Models;

namespace AppConfigTest.Controllers
{
    public class DerivedController : Controller
    {
        public IActionResult Index()
        {
            var res = Request.Path.Value;
            var res1 = Request.Path;


            return View("Result", Request.Headers.ToDictionary(kvp => kvp.Key,
                kvp => kvp.Value.First()));
        }




        
    }
}
