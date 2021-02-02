using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new string[] { "Apple", "Orange", "Pear" });
        }

        public IActionResult List() => View();
    }
}
