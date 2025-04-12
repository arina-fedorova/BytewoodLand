using Authix.Auth.Endpoints;
using Authix.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddDbContext<AuthixDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlite(connString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapLoginEndpoint();
app.MapGuestEndpoint();

app.Run();
