using Authix.Auth.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/token", (string username, IConfiguration config) =>
{
    var user = UserStore.Find(username);
    var jwtOptions = config.GetSection("Jwt").Get<JwtOptions>();

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role.ToString().ToLower())
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: jwtOptions.Issuer,
        audience: jwtOptions.Audience,
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: creds
    );

    return Results.Ok(new
    {
        token = new JwtSecurityTokenHandler().WriteToken(token)
    });
});

app.Run();
