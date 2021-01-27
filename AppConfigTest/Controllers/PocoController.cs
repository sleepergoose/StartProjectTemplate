using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace AppConfigTest.Controllers
{
    [Controller] // - class is controller
    // [NonController] // - class isn't controller
    public class PocoController
    {
        [ControllerContext]
        public ControllerContext ctx { get; set; }

        [NonAction] // - method isn't action
        public string IsNotActionMethod() => "This is a POCO Controller";

        public void Index() 
        {
            ctx.HttpContext.Response.BodyWriter.WriteAsync(System.Text.Encoding.ASCII.GetBytes("Hello, W!"));
        }
    }
}
