using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class ShabbatMiddleware
{
    private readonly RequestDelegate _next;

    public ShabbatMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("הגישה חסומה בשבת.");
            return;
        }

        await _next(context);
    }
}
