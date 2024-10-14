using Microsoft.AspNetCore.Mvc;
using server.Endpoints;
using server.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsersDb>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

Endpoints.MapGetEndpoints(app);
Endpoints.MapPostEndpoints(app);




app.Run();