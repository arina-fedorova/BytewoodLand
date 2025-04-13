using Authix.Auth.Models;
using Authix.Data.Models;
using Bytewood.Contracts.Roles;
using Microsoft.EntityFrameworkCore;

namespace Authix.Data;

public class AuthixDbContext : DbContext
{
    public AuthixDbContext(DbContextOptions<AuthixDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<ServiceClient> ServiceClients => Set<ServiceClient>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();

        modelBuilder.Entity<User>()
            .HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User!)
            .HasForeignKey(rt => rt.UserId);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1, Username = "Nymera", Role = UserRole.Guardian,
                PasswordHash = "$2a$11$EIHWWJGyhqD7GPpX8XkoNOOm/ZB7LkqHIJNbN7/x2TkVNA.3sdHS2"
            },
            new User
            {
                Id = 2, Username = "Erlic", Role = UserRole.Scout,
                PasswordHash = "$2a$11$0DglUrJi7XWB447cDHgo5eXfQK8vj.dUb6OgNRw3F.sfUiaKuE/1."
            },
            new User
            {
                Id = 3, Username = "Thorne", Role = UserRole.Scout,
                PasswordHash = "$2a$11$wlJZ18hweIKOtEmPysmJtelJHYT7Oyy0c9qDaI2I.cjQx7w0/AzPm"
            }
        );

        modelBuilder.Entity<ServiceClient>().HasData(
            new ServiceClient
            {
                Id = 1, ClientId = "unity.gateway", Role = ServiceRole.Gateway,
                SecretHash = "$2a$11$VhT1VfQFjsG4UfPQPPAjDu7xYHjX6BOyrg9L/cFByP9AlSU8fucXm"
            },
            new ServiceClient
            {
                Id = 2, ClientId = "authix.auth", Role = ServiceRole.Identity,
                SecretHash = "$2a$11$Z.KnTJd5075lQk2DdKDbB.cPsRaSvi505WURWc5ezSvrdicairlw."
            },
            new ServiceClient
            {
                Id = 3, ClientId = "casha.cache", Role = ServiceRole.Cache,
                SecretHash = "$2a$11$WaMKv4/fWsWqsNTu/3.jie53/byZXUEgSukK0UoBzzFeUa/jelDNO"
            },
            new ServiceClient
            {
                Id = 4, ClientId = "owla.observer", Role = ServiceRole.Observer,
                SecretHash = "$2a$11$hPF4./QJd2.VsqJybGjLqenqUoq/G6gl9iiMDI9LrHWrTaepjtHfK"
            },
            new ServiceClient
            {
                Id = 5, ClientId = "tweetle.messenger", Role = ServiceRole.Messenger,
                SecretHash = "$2a$11$5HCAh89d5k1SmxE7ax/CNeFTSOaw9eQ8SkZy.4bFjEkiVcvGIYDv2"
            },
            new ServiceClient
            {
                Id = 6, ClientId = "squee.scheduler", Role = ServiceRole.Scheduler,
                SecretHash = "$2a$11$t6gr29Wv0N/fj4t4ncZEeeOcpaFLGWMPrkU9r10rg37uokhq57N8W"
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}