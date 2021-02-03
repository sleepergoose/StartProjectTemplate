using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppConfigTest.Models;
using Microsoft.AspNetCore.Mvc;

using viewComponents = Microsoft.AspNetCore.Mvc.ViewComponents;
using html = Microsoft.AspNetCore.Html;

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

        public IViewComponentResult Invoke()
        {
            if (ViewContext.RouteData.Values["id"] as string == "true")
            {
                return View("CityList", repository.Cities);
            }
            else
            {
                return View(new CityViewModel
                {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(p => p.Population)
                });
            }
        }
        //public IViewComponentResult Invoke()
        //{
        //    string target = ViewContext.RouteData.Values["id"] as string;
        //    var e = ViewContext.HttpContext.Request.RouteValues["id"];
        //    var r = ViewContext.RouteData.Values;
        //    var t = ViewContext.ViewData;

        //    var cities = repository.Cities
        //        .Where(city => target == null || string.Compare(city.Country, target, true) == 0);

        //    return View(new CityViewModel
        //    {
        //        Cities = cities.Count(),
        //        Population = cities.Sum(p => p.Population)
        //    });
        //}

        //public IViewComponentResult Invoke()
        //{
        //    //ViewBag.SomeData = "It's great!";
        //    return View(new CityViewModel {
        //        Cities = repository.Cities.Count(),
        //        Population = repository.Cities.Sum(p => p.Population)
        //    });
        //}

        /*
         * Метод Content() кодирует переданную ему в качестве аргумента строку, 
         * чтобы она стала безопасной. То есть HTML кодируется в простой текст. 
         * JavaScript удаляется
         */
        // public IViewComponentResult Invoke() => Content($@"This is a <h3><i>string</i></h3>");

        /*
         * Если нужно передать именно HTML-разметку
         */

        //public IViewComponentResult Invoke()
        //{
        //    
        //    return new viewComponents.HtmlContentViewComponentResult(
        //            new html.HtmlString($@"This is a <h3><i>string</i></h3>"));
        //}
    }
}
