using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppConfigTest.Models;
using Microsoft.AspNetCore.Mvc;

using AppConfigTest.Models.ViewModels;

namespace AppConfigTest.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke() => View(new CityViewModel
        {
            Cities = repository.Cities.Count(),
            Population = repository.Cities.Sum(p => p.Population)
        });
    }
}
