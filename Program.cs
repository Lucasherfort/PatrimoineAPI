using Microsoft.EntityFrameworkCore;
using WebApplicationPatrimoine.Data;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Services
// =======================

// Controllers
builder.Services.AddControllers();

// DbContext MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default"))
    );
});

// Swagger / OpenAPI (Swashbuckle)
builder.Services.AddEndpointsApiExplorer(); // nécessaire pour Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =======================
// Middleware
// =======================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // génère le JSON Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatrimoineAPI v1");
        c.RoutePrefix = string.Empty; // Swagger à la racine : https://localhost:7129/
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
