using Microsoft.EntityFrameworkCore;
using FinalProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Final Project API";
});

var app = builder.Build();

app.UseOpenApi();

app.UseSwaggerUi(config =>
{
    config.Path = "/swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();