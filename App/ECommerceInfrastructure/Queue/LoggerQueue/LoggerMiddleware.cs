using Microsoft.AspNetCore.Http;

namespace ECommerceInfrastructure.Queue.LoggerQueue;

public sealed class LoggerMiddleware(RequestDelegate next)
{
    readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        LoggerQueueHandler.InsertRequest(LoggerQueueFilter.RequestFilter(context));

        await _next(context);

        LoggerQueueHandler.InsertResponse(LoggerQueueFilter.ResponseFilter(context));
    }
}
