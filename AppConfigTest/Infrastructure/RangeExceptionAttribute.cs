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
    public class RangeExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //if (context.Exception is Exception)
            //{
                context.Result = new ViewResult()
                {
                    ViewName = "Index",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                                {
                                    Model = @"The data received by the application cannot be processed"
                                }
                };
            //}
        }
    }
}
