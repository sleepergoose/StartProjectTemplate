using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppConfigTest.Controllers
{
    public class HomeController : Controller
    {
        [ControllerContext]
        public ControllerContext ControllerContex { get; set; }
        public IActionResult Index()
        {
            var model = (object)(TempData["name"] as string);
            TempData.Keep("name");
            
            return View(model);
        }

        public IActionResult RedirectView() => View("RedirectView");

        public ViewResult Data()
        {
            string name = TempData.Peek("name") as string;
            string city = TempData["city"] as string;

           
            return View("Result", $"name: {name}; city: {city}");
        }

        [HttpPost]
        public RedirectToActionResult ReceiveForm(string Name, string CITY)
        {
            // ======
            TempData["name"] = Name;
            TempData["city"] = CITY;
            return RedirectToAction(nameof(Data));



            // ======
            //Response.StatusCode = 200;
            //Response.ContentType = "text/html";

            //string cont = $"<!DOCTYPE html>" +
            //    $"<html><head><title>@ViewBag.Title</title><link href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css \" rel=\"stylesheet\" /></head>" +
            //    $"<body><div class=\"container display-4\">{Name} lives in {CITY}</div></body><html>";
            
            //byte[] content = Encoding.ASCII.GetBytes(cont);
            //Response.Body.WriteAsync(content, 0, content.Length);

            /* ===== */
            //var name = Request.Form["name"];
            //var city = Request.Form["city"];

            //return View("Result", new Dictionary<string, string>() { ["Form Data:"] = 
            //    $"{name} lives in {city}"});
        }
    }
}
