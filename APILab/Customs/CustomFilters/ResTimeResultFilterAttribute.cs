using Microsoft.AspNetCore.Mvc.Filters;

namespace APILab.Customs.CustomFilters
{
    public class ResTimeResultFilterAttribute: Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers["IP"] = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            context.HttpContext.Items["StartTime"] = DateTime.UtcNow; // before writing the response
        }
        public void OnResultExecuted(ResultExecutedContext context)  // after writing the response 
        {
            var start = (DateTime)context.HttpContext.Items["StartTime"];
            var elapsed = DateTime.UtcNow - start;
            Console.WriteLine($"Response took: {elapsed.TotalMilliseconds}ms, IP => {context.HttpContext.Response.Headers["IP"]}");
        }
    }
}

/*
 return Ok(data)
    ↓
OkObjectResult object created in memory
    ↓
OnResultExecuting fires
    ↓
OkObjectResult.ExecuteResultAsync() called   ← HERE is where writing happens
    │
    ├── serializes data to JSON
    ├── sets Content-Type header
    └── writes bytes to HTTP response stream
    ↓
OnResultExecuted fires  -> response has been written and finished
 */