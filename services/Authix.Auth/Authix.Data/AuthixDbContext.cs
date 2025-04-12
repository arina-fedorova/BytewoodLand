using Authix.Auth.Models;
using Authix.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Authix.Data;
public class AuthixDbContext : DbContext
{
    public AuthixDbContext(DbContextOptions<AuthixDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "Squee", Role = Role.Scout, PasswordHash = BCrypt.Net.BCrypt.HashPassword("squeescout") },
            new User { Id = 2, Username = "Owla", Role = Role.Scout, PasswordHash = BCrypt.Net.BCrypt.HashPassword("owlascout") },
            new User { Id = 3, Username = "Casha", Role = Role.Guardian, PasswordHash = BCrypt.Net.BCrypt.HashPassword("cashaguardian") },
            new User { Id = 4, Username = "Tweetle", Role = Role.Scout, PasswordHash = BCrypt.Net.BCrypt.HashPassword("tweetlescout") },
            new User { Id = 5, Username = "Grizzle", Role = Role.Guardian, PasswordHash = BCrypt.Net.BCrypt.HashPassword("grizzleguardian") }
        );
    }
}
