using UsersService.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Users Service API",
        Version = "v1",
        Description = "Microservice responsible for managing users"
    });
});

// Health Checks
builder.Services.AddHealthChecks();

// CORS configuration to allow frontend on port 4200
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Registrar servicios de la aplicaci�n
builder.Services.AddApplicationServices();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.MapControllers();

// Endpoint /health
app.MapHealthChecks("/health");
app.Urls.Add("http://0.0.0.0:8080");
app.Run();