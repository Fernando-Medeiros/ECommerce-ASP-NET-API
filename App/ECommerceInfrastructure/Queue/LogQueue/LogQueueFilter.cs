using ECommerceInfrastructure.Persistence.Models;

namespace ECommerceInfrastructure.Queue.LogQueue;

public static class LogQueueFilter
{
    public static LogRequest RequestFilter(HttpContext ctx)
    {
        return new()
        {
            Scheme = ctx.Request.Scheme,
            HttpMethod = ctx.Request.Method,
            Controller = GetRouteValue(ctx, "controller"),
            Action = GetRouteValue(ctx, "action"),
            Path = ctx.Request.Path,
            CreatedOn = DateTime.UtcNow
        };
    }

    public static LogResponse ResponseFilter(HttpContext ctx)
    {
        return new()
        {
            Scheme = ctx.Request.Scheme,
            HttpMethod = ctx.Request.Method,
            Controller = GetRouteValue(ctx, "controller"),
            Action = GetRouteValue(ctx, "action"),
            Path = ctx.Request.Path,
            StatusCode = ctx.Response.StatusCode,
            CreatedOn = DateTime.UtcNow
        };
    }

    private static string? GetRouteValue(HttpContext ctx, string keySelector)
    {
        return (string?)ctx.Request.RouteValues.GetValueOrDefault(keySelector) ?? "Not Implemented";
    }
}
