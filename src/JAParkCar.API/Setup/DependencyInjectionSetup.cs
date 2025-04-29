using JAParkCar.Application.Interfaces;
using JAParkCar.Application.Mapper;
using JAParkCar.Application.Services;
using JAParkCar.Domain.Interfaces;
using JAParkCar.Infra.Database.Repositories;

namespace JAParkCar.API.Setup;

public static class DependencyInjectionSetup
{
    public static void AddDiConfig(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddServices();
        services.AddAutoMapper(typeof(AutoMapperConfig));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICarRepository, CarRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
    }
}