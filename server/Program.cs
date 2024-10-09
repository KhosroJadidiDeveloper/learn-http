using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using server.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

Endpoints.MapGetEndpoints(app);



app.Run();