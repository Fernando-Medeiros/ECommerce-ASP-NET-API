using ECommerceCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ECommerceInfrastructure.Exceptions;

public sealed class ExceptionMiddleware(RequestDelegate next)
{
    readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.Value.StatusCode;
            await Write(context, ex.Value);
        }
        catch (DbUpdateException ex)
        {
            context.Response.StatusCode = 500;
            await Write(context, new { ex.Message });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await Write(context, new { ex.Message });
        }
    }

    private static async Task Write(HttpContext context, object result)
    {
        context.Response.ContentType = "application/json";
        var json = JsonSerializer.Serialize(result);
        await context.Response.WriteAsync(json);
    }

}
