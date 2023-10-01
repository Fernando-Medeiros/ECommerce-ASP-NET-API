using ECommerceDomain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceInfrastructure.Filters;

public sealed class DomainExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 8;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is DomainException currentException)
        {
            context.Result = new ObjectResult(currentException.Value)
            {
                StatusCode = currentException.Value.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}