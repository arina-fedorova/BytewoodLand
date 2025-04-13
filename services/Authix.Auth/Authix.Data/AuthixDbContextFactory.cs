using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Authix.Data;

public class AuthixDbContextFactory : IDesignTimeDbContextFactory<AuthixDbContext>
{
    public AuthixDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../data");
        Directory.CreateDirectory(basePath);
        var dbPath = Path.Combine(basePath, "bytewood_authix.db");

        var optionsBuilder = new DbContextOptionsBuilder<AuthixDbContext>();
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        return new AuthixDbContext(optionsBuilder.Options);
    }
}