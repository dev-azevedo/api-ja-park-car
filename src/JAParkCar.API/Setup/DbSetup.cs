using JAParkCar.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.API.Setup;

public static class DbSetup
{
    public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var databasePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "japarkcar.sqlite");
            options.UseSqlite($"Data Source={databasePath}");
        });
    }
}