using AppConfigTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Controllers
{
    [ViewComponent(Name = "ComboComponent")]
    public class CityController : Controller
    {
        private ICityRepository repository;

        public CityController(ICityRepository repo)
        {
            repository = repo;
        }

        public IActionResult Create() => View("Create");

        [HttpPost]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke() => new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData, repository.Cities)
        };
    }
}
