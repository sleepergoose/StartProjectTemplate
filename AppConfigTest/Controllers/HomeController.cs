using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppConfigTest.Models;

namespace AppConfigTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("Result", new Result
        {
            Controller = nameof(HomeController),
            Action = nameof(Index)
        });

        public IActionResult CustomVariable(string id)
        {
            Result r = new Result { Controller = nameof(HomeController), Action = nameof(Index) };
            r.Data["id"] = id ?? "<no value>"; // RouteData.Values["id"];

            r.Data["catchall"] = RouteData.Values["catchall"];
            r.Data["url"] = Url.Action("Index", "Admin");
            return View("Result", r);
        }
    }
}
