using InterviewSolution.Model;
using InterviewSolution.Model.Entity;
using InterviewSolution.Model.Repository;
using InterviewSolution.Service;
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
builder.Services.AddTransient<DataContext, DataContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
