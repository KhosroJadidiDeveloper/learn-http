using Microsoft.AspNetCore.Mvc;

namespace server.Endpoints;

internal static class Endpoints
{
    internal static void MapGetEndpoints(WebApplication app)
    {
        app.MapGet("/fail", (ILogger<Program> logger) =>
        {
            logger.LogInformation("failure GET was called");
            return Results.NotFound("The GET request was a failure");
        });

        app.MapGet("/success", ([FromQuery] string id, [FromQuery] int age, ILogger<Program> logger) =>
        {
            logger.LogInformation("success GET was called");
            return Results.Ok(new
            {
                Id = id,
                Age = age
            });
        });
    }
}