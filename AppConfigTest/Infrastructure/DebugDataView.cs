using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace AppConfigTest.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path => String.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Request.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("----Routing Data----\n\r");
            foreach (var kvp in context.RouteData.Values)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}\n\r");
            }

            sb.AppendLine("----View Data----\n\r");
            foreach (var kvp in context.ViewData)
            {
                sb.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}\n\r");
            }

            await context.Writer.WriteAsync(sb.ToString());
        }
    }
}
