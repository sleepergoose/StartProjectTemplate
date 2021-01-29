using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AppConfigTest.Infrastructure
{
    /// <summary>
    /// Class of the Filter
    /// </summary>
    public class HttpsOnlyAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.IsHttps == false)
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
        }
    }
}
