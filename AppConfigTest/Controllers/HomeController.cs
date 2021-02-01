using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppConfigTest.Models;

namespace AppConfigTest.Controllers
{
    public class HomeController: Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Reservations);
        }

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                repository.AddReservation(reservation);
            }
            return RedirectToAction("Index");
        }
    }
}
