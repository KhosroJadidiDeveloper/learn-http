using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.MapGet("/success/{id}/", (string id, [FromQuery]int age, ILogger<Program> logger) =>
{
    logger.LogInformation("success GET was called");
    var response = JsonSerializer.Serialize(new
    {
        id
    });
    return Results.Ok(response);
});

app.Run();