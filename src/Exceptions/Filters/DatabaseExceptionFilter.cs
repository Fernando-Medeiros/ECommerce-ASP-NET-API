using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Exceptions;

public class DatabaseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 11;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is DbUpdateException currentDbException)
        {
            context.Result = new ObjectResult(currentDbException.Data)
            {
                StatusCode = 500,
                Value = new { message = currentDbException.Message }
            };
            context.ExceptionHandled = true;
        }
    }
}
