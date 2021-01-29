using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigTest.Infrastructure
{
    public class ProfileAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            timer = Stopwatch.StartNew();
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = $"<div class=\"container w-50\"><p>{timer.Elapsed.TotalMilliseconds.ToString()} ms</p></div>";
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }


        //public override async Task OnActionExecutionAsync(ActionExecutingContext context,
        //ActionExecutionDelegate next)
        //{
        //    timer = Stopwatch.StartNew();

        //    await next();

        //    timer.Stop();
        //    string result = $"<div class=\"container w-50\"><p>{timer.Elapsed.TotalMilliseconds.ToString()} ms</p></div>";
        //    byte[] bytes = Encoding.ASCII.GetBytes(result);
        //    await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);

        //}
    }



}
