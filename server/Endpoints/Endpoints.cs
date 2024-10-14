using Microsoft.AspNetCore.Mvc;

namespace server.Endpoints;

internal static class Endpoints
{
    internal static void MapGetEndpoints(WebApplication app)
    {
        app.MapGet("/", ([FromHeader]string khosro, ILogger<Program> logger) =>
        {
            logger.LogInformation("success GET was called");
            return Results.Ok(new
            {
                FromHeader = khosro
            });
        });
    }
}