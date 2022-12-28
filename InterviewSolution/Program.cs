using InterviewSolution.Middleware;
using InterviewSolution.Model;
using InterviewSolution.Model.Repository;
using InterviewSolution.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// CORs Policty
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicty", builder =>
    {
        builder
        .WithOrigins("http://localhost:3000");
    });
});

// Dependency Injection
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepositoryCrudAsync, OrderRepositoryCrudAsync>();
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOpts =>
{
    swaggerGenOpts.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET Delivery App by Alim Kugotov", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUIOptions =>
    {
        swaggerUIOptions.DocumentTitle = "Delivery App Swagger";
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

// Apply Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

app.Run();
