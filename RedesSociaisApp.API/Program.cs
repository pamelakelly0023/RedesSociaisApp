using RedesSociaisApp.Infrastructure;
using RedesSociaisApp.Application;
using Microsoft.OpenApi.Models;
using RedesSociaisApp.API.Endpoints;
using RedesSociaisApp.Application.Exceptions;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddEndpointsApiExplorer()
    .AddExceptionHandler<GlobalExceptionHandler>()
    .AddProblemDetails()
    .AddInfrastructure(builder.Configuration);

// builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
// builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
// app.UseHttpsRedirection();
app.UseExceptionHandler();

app.Run();

