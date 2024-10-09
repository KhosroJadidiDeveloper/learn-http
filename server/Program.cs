using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using server.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Endpoints.MapGetEndpoints(app);

app.Run();