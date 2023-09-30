namespace ECommerceInfrastructure.Queue.LogQueue;

public sealed class LogQueueMiddleware
{
    private readonly RequestDelegate _next;

    public LogQueueMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        LogQueueHandler.InsertRequest(LogQueueFilter.RequestFilter(context));

        await _next(context);

        LogQueueHandler.InsertResponse(LogQueueFilter.ResponseFilter(context));
    }
}
