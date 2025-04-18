using System.Security.Claims;
using System.Text;
using Authix.Auth.Configuration;
using Authix.Auth.Endpoints;
using Authix.Data;
using Bytewood.Contracts.Roles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOptions = JwtSettingsProvider.Get(builder.Configuration);
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization(options =>
{
    // User-based policies
    options.AddPolicy("GuardianOnly", policy =>
        policy.RequireRole(UserRole.Guardian.AsString()));
    
    options.AddPolicy("ScoutOnly", policy =>
        policy.RequireRole(UserRole.Scout.AsString()));

    options.AddPolicy("AnyUser", policy =>
        policy.RequireAssertion(context =>
            Enum.TryParse<UserRole>(context.User.FindFirstValue(ClaimTypes.Role), true, out var role) &&
            role != UserRole.Wanderer
        ));

    // Service-based policies
    options.AddPolicy("WardenOnly", policy =>
        policy.RequireRole(ServiceRole.Observer.AsString()));

    options.AddPolicy("IdentityOnly", policy =>
        policy.RequireRole(ServiceRole.Identity.AsString()));

    options.AddPolicy("TrustedService", policy =>
        policy.RequireAssertion(context =>
            Enum.TryParse<ServiceRole>(context.User.FindFirstValue(ClaimTypes.Role), true, out _)
        ));
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapLoginEndpoint();
app.MapGuestEndpoint();
app.MapRefreshEndpoint();
app.MapDeleteTokenEndpoint();
app.MapClientAuthEndpoint();
app.MapIntrospectionEndpoint();

app.Run();