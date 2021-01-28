using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppConfigTest.Infrastructure;
using AppConfigTest.Models;

namespace AppConfigTest.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public static int Counter = 0;
        // private ProductTotalizer totalizer;

        public HomeController(IRepository repo /*, ProductTotalizer total*/)
        {
            Counter++;
            repository = repo;
            //totalizer = total;
        }

        public IActionResult Index([FromServices]ProductTotalizer productTotalizer)
        {
            ViewBag.Total = productTotalizer.Total;
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = productTotalizer.Repository.ToString();

            return View(repository.Products);
        }
    }
}
