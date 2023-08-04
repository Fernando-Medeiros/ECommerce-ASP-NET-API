using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Exceptions;

public class HttpExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is HttpResponseException currentException)
        {
            context.Result = new ObjectResult(currentException.Value)
            {
                StatusCode = currentException.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}
