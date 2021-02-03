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
        private ICityRepository repository;
        public HomeController(ICityRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                repository.AddCity(city);
                return RedirectToAction("Index");
            }
            else
            {
                return View(city);
            }
        }
    }
}
