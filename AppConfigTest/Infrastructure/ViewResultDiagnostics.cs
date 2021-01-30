using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Infrastructure
{
    public class ViewResultDiagnostics : IActionFilter
    {
        private IFilterDiagnostics diagnostics;

        public ViewResultDiagnostics(IFilterDiagnostics diags) => diagnostics = diags;
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            ViewResult vr = context.Result as ViewResult;
            if (vr != null)
            {
                diagnostics.AddMessage($"View name: {vr.ViewName}");
                diagnostics.AddMessage($@"Model type: {vr.ViewData.Model.GetType().Name}");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // 
        }
    }
}
