using JAParkCar.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.API.Setup;

public static class DbSetup
{
    public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite(configuration.GetConnectionString("ConnectionSqlite"))
        );
    }
}