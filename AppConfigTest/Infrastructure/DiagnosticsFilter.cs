using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Infrastructure
{
    public class DiagnosticsFilter : IAsyncResultFilter
    {
        private IFilterDiagnostics diagnostics;

        public DiagnosticsFilter(IFilterDiagnostics diags)
        {
            diagnostics = diags;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();

            foreach (string message in diagnostics?.Message)
            {
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes($@"<div>{message}</div>");
                await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);

            }
        }
    }
}
