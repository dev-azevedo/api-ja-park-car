using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JAParkCar.Infra.Database.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var databasePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "japarkcar.sqlite");
        optionsBuilder.UseSqlite($"Data Source={databasePath}");

        return new AppDbContext(optionsBuilder.Options);
    }
}