using Microsoft.AspNetCore.Mvc;
using server.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

Endpoints.MapGetEndpoints(app);

app.MapPost("/success", (ILogger<Program> logger, [FromBody] string body) =>
{
    logger.LogInformation("success POST was called");
    return Results.Created("Created successfully.",new
    {
        Message = "Got the body",
        Body = body
    });
});


app.Run();