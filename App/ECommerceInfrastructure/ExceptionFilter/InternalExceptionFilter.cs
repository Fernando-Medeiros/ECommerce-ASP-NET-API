using ECommerceCommon;
using ECommerceInfrastructure.ExceptionFilter.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInfrastructure.ExceptionFilter;

public sealed class InternalExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (
            context?.Exception?.GetType() != typeof(CustomException) &&
            context?.Exception?.GetType() != typeof(DbUpdateException) &&
            context?.Exception?.GetType() == typeof(Exception))
        {
            var exception = new InternalException(
                message: context?.Exception?.Message ?? "",
                details: new()
                {
                    context?.Exception?.Source ?? "",
                    context?.Exception?.InnerException?.Message ?? ""
                })
                .Target(nameof(InternalExceptionFilter));

            context!.Result = new ObjectResult(exception.Value)
            {
                StatusCode = exception.Value.StatusCode,
            };
            context.ExceptionHandled = true;
        }
    }

}