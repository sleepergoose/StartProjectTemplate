using Microsoft.AspNetCore.Mvc.Filters;

namespace AppConfigTest.Infrastructure
{
    public class MessageAttribute : ResultFilterAttribute
    {
        private string message;

        public MessageAttribute(string msg)
        {
            message = msg;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            WriteMessage(context, $@"<div>Before Result: {message}</div>");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            WriteMessage(context, $@"<div> After Result: {message}</div>");
        }

        private void WriteMessage(FilterContext context, string msg)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(msg);
            context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
