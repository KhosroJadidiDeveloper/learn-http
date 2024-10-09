using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace server.Endpoints;

internal static class Endpoints
{
    internal static void MapGetEndpoints(WebApplication app)
    {
        app.MapGet("/success", (ILogger<Program> logger) =>
        {
            logger.LogInformation("success GET was called");
            return Results.Ok("The GET request was successful");
        });

        app.MapGet("/fail", (ILogger<Program> logger) =>
        {
            logger.LogInformation("failure GET was called");
            return Results.NotFound("The GET request was a failure");
        });

        app.MapGet("/success/{id}", (string id, [FromQuery]int age, ILogger<Program> logger) =>
        {
            logger.LogInformation("success GET was called");
            var response = JsonSerializer.Serialize(new
            {
                id
            });
            return Results.Ok(response);
        });

    }
}