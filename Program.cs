using full_structure_db.Common;
using full_structure_db.Data;
using full_structure_db.Exception;
using full_structure_db.Repositories;
using full_structure_db.Repositories.Impl;
using full_structure_db.Services;
using full_structure_db.Services.Impl;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repository & Service
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Controller
builder.Services.AddControllers();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS
app.UseHttpsRedirection();

// -------------------------------
// Global Exception Handler
// -------------------------------
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            var exception = contextFeature.Error;

            // Map custom exceptions to HTTP status code
            int statusCode = exception switch
            {
                ResourceNotFoundException => StatusCodes.Status404NotFound,
                DuplicateResourceException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            // Create ApiError response
            var apiError = new ApiError(
                message: exception.Message,
                code: statusCode,
                details: null
            )
            {
                Success = false
            };

            // Set HTTP response code
            context.Response.StatusCode = statusCode;

            // Send JSON response to client
            await context.Response.WriteAsJsonAsync(apiError);
        }
    });
});

// Map controllers
app.MapControllers();

// Run the app
app.Run();