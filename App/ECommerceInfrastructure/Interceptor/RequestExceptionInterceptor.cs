using ECommerceInfrastructure.Interceptor.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceInfrastructure.Interceptor;

public class RequestExceptionInterceptor : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 7;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is ValidationException currentException)
        {
            var exception = new RequestValidationException()
                .SetMessage(currentException.Message)
                .SetDetails(currentException.Errors.Select(e => e.ErrorMessage).ToList())
                .SetTarget(nameof(RequestExceptionInterceptor));

            context.Result = new ObjectResult(exception.Value)
            {
                StatusCode = exception.Value.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}