//using DotNetEnv;
using Microsoft.OpenApi.Models;
using SafeCap.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using SafeCap.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Env.Load();

builder.Services.AddAutoMapper(typeof(UserMapping));
builder.Services.AddAutoMapper(typeof(SensorReadingMapping));
builder.Services.AddAutoMapper(typeof(AlertMapping));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API do projeto Fleetzone",
        Version = "v1",
        Description = "API do projeto Fleetzone da challenge do Ultimo semestre de 2025.",
    });
});

//var oracleConnectionString = Environment.GetEnvironmentVariable("ORACLE_CONNECTION_STRING");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // Garante que escute no Docker
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
