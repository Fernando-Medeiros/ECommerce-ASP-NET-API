using ECommerceDomain.Abstractions;
using ECommerceInfrastructure.Interceptor.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.Interceptor;

public class InternalExceptionInterceptor : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (
            context.Exception is not DomainException &&
            context.Exception is not DbUpdateException &&
            context.Exception is not ValidationException)
        {
            var exception = new InternalException()
                .SetMessage(context?.Exception?.Message ?? "")
                .SetDetails(new() {
                    context?.Exception?.Source ?? "",
                    context?.Exception?.InnerException?.Message ?? "" })
                .SetTarget(nameof(InternalExceptionInterceptor));

            context!.Result = new ObjectResult(exception.Value)
            {
                StatusCode = exception.Value.StatusCode
            };
            context.ExceptionHandled = true;
        }
    }

}