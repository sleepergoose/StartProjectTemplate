using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AppConfigTest.Controllers
{
    public class ExampleController : Controller
    {
        public JsonResult Index() => Json(new[] { "Result", "one", "two" });

        public StatusCodeResult SCResult() => StatusCode(StatusCodes.Status504GatewayTimeout);

        public RedirectToRouteResult Redirect() => RedirectToRoute(new { controller="Home", 
                        action= "RedirectView"});
    }
}
