// using Microsoft.Extensions.FileProviders;
// using Microsoft.EntityFrameworkCore;
// using MyCatalogApi.webapi.Data;

// var builder = WebApplication.CreateBuilder(args);

// // Add services

// builder.Services.AddSwaggerGen();

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//                        ?? Environment.GetEnvironmentVariable("DATABASE_URL");

// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseNpgsql(connectionString));


// // CORS for your frontend
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin() // TODO: replace with actual frontend URL
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//     });
// });

// builder.Services.AddControllers();

// var app = builder.Build();

// // Static files (wwwroot/assets)
// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(
//         Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets")),
//     RequestPath = "/assets"
// });

// app.Use(async (context, next) =>
// {
//     var logger = app.Logger;
//     logger.LogInformation("➡️ Request: {Method} {Path}", 
//         context.Request.Method, 
//         context.Request.Path);

//     await next.Invoke();

//     logger.LogInformation("⬅️ Response: {StatusCode} {Path}", 
//         context.Response.StatusCode, 
//         context.Request.Path);
// });



// // Health check
// app.MapGet("/health", () => Results.Ok("Healthy"));

// app.MapGet("/ping", () =>
// {
//     return Results.Text("Flutter Backend is running on Render! ☠️🔥💖", statusCode: 200);
// });


// // Swagger
// app.UseSwagger();
// app.UseSwaggerUI(c =>
// {
//     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//     c.RoutePrefix = string.Empty; // Swagger at "/"
// });

// // Middleware
// app.UseCors("AllowAll");
// app.UseAuthorization();

// app.MapControllers();

// app.Run();


using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using MyCatalogApi.webapi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? Environment.GetEnvironmentVariable("DATABASE_URL");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// CORS for your frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // TODO: replace with actual frontend URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// ✅ Request/Response Logging Middleware
app.Use(async (context, next) =>
{
    var logger = app.Logger;
    logger.LogInformation("➡️ Request: {Method} {Path}",
        context.Request.Method,
        context.Request.Path);

    await next.Invoke();

    logger.LogInformation("⬅️ Response: {StatusCode} {Path}",
        context.Response.StatusCode,
        context.Request.Path);
});

// ✅ Static files (wwwroot/assets)
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets")),
    RequestPath = "/assets"
});

// ✅ Health check
app.MapGet("/health", () => Results.Ok("Healthy"));


// ✅ Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger at "/"
});

// ✅ Middleware
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();

