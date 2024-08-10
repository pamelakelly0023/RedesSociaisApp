using Microsoft.EntityFrameworkCore;
using RedesSociaisApp.Infrastructure.Persistence;
using RedesSociaisApp.Infrastructure;
using System.Text.Json.Serialization;
using RedesSociaisApp.Application;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using RedesSociaisApp.API.Endpoints;
using System.Reflection;
using MediatR;
using RedesSociaisApp.API.Middlewares;
using RedesSociaisApp.Application.Exceptions;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddEndpointsApiExplorer()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(); 

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Acesso protegido utilizando o accessToken obtido em \"api/Authenticate/login\""
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }  
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapContaEndpoint();
app.UseHttpsRedirection();
app.UseExceptionHandler();

app.Run();

