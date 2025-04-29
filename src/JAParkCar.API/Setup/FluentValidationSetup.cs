using FluentValidation;
using FluentValidation.AspNetCore;
using JAParkCar.Application.Validator.Car;

namespace JAParkCar.API.Setup;

public static class FluentValidationSetup
{
    public static void AddFluentValidationSetup(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CarCreateValidator>();
        services.AddValidatorsFromAssemblyContaining<CarUpdateValidator>();
    }
}