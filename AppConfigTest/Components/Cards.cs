using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppConfigTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppConfigTest.Components
{
    public class Cards : ViewComponent
    {
        private ICardRepository repository;
        public Cards(ICardRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.Cards);
        }
    }
}
