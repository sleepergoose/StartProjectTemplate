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
        private IProductRepository repository;

        public HomeController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public IActionResult Index() => View(repository.Products);
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
