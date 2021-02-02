using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Infrastructure
{
    public class DebugDataViewEngine : IViewEngine
    {
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            if (viewName == "DebugData")
            {
                return ViewEngineResult.Found(viewName, new DebugDataView());
            }
            else
            {
                return ViewEngineResult.NotFound(viewName, 
                    new string[] { "(Debug View Engine - Find View)" });
            }
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, 
                new string[] { "(Debug View Engine - Get View)" });
        }
    }
}
