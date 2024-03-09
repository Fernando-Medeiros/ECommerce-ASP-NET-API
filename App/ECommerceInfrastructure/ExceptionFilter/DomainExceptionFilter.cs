using ECommerceCommon;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceInfrastructure.ExceptionFilter;

public sealed class DomainExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 8;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is CustomException currentException)
        {
            context.Result = new ObjectResult(currentException.Value)
            {
                StatusCode = currentException.Value.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}