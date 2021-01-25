using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppConfigTest.Models;

namespace AppConfigTest.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index() => View("Result", new Result
        {
            Controller = nameof(CustomerController),
            Action = nameof(Index)
        });

        public IActionResult List() => View("Result", new Result
        {
            Controller = nameof(CustomerController),
            Action = nameof(List)
        });
    }
}
