using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Filters;

public sealed class DatabaseUpdateExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 9;

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