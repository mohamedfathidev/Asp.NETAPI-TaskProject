using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APILab.Customs.CustomFilters
{
    public class ExceptionFilterAttribute: Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new { message = "Exception Error Filter", error = context.Exception.Message });
            context.HttpContext.Response.StatusCode = 500;
            context.ExceptionHandled = true; // stop propagation, if False middleware exception will catch it also but already filter write to response firstly 
        }
    }
}
