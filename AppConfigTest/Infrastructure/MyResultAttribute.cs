using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfigTest.Infrastructure
{
    public class MyResultAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            ViewResult vresult;
            var t = (context.Result as ViewResult).ViewData.Model;
            var temp = (context.Result as ViewResult).Model.GetType().Name;
            if (temp.ToLower() == "double")
            {
                vresult = new ViewResult
                {
                    ViewName = "Double",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                    new ModelStateDictionary())
                    {
                        Model = t
                    }
                };
                context.Result = vresult;
            }
        }
    }
}
