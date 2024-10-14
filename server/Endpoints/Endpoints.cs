using Microsoft.AspNetCore.Mvc;
using server.Entities;
using server.Persistence;

namespace server.Endpoints;

internal static class Endpoints
{
    private static UsersDb UsersDb = new();

    internal static void MapGetEndpoints(WebApplication app)
    {
        app.MapGet("/", ([FromHeader] string khosro, ILogger<Program> logger) =>
        {
            logger.LogInformation("success GET was called");
            return Results.Ok(new
            {
                FromHeader = khosro
            });
        });
    }

    internal static void MapPostEndpoints(WebApplication app)
    {
        app.MapPost("/", (ILogger<Program> logger, [FromServices] UsersDb usersDb, [FromBody] User user) =>
        {
            logger.LogInformation("post called with: {User}",user);
            return Results.Created("Created successfully.", new
            {
                Message = "Got the body",
                Body = user
            });
        });
    }

    internal static void MapPutEndpoints(WebApplication app)
    {
        app.MapPost("/{id:int}", (ILogger<Program> logger, [FromRoute] int id) => { });
    }
}