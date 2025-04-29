using FluentValidation;
using JAParkCar.Application.DTO.Car;

namespace JAParkCar.Application.Validator.Car;

public class CarCreateValidator :  AbstractValidator<CarCreateDto>
{
    public CarCreateValidator()
    {
        RuleFor(c => c.Brand)
            .NotEmpty().WithMessage("Car brand cannot be empty")
            .Length(2, 100).WithMessage("Car brand must be between 2 and 100 characters");
        
        RuleFor(c => c.Model)
            .NotEmpty().WithMessage("Car model cannot be empty")
            .Length(2, 100).WithMessage("Car model must be between 2 and 100 characters");
        
        RuleFor(c => c.Color)
            .NotEmpty().WithMessage("Car color cannot be empty")
            .Length(2, 50).WithMessage("Car color must be between 2 and 50 characters");
        
        RuleFor(c => c.CarPlate)
            .NotEmpty().WithMessage("Car plate cannot be empty")
            .Length(7).WithMessage("Car plate must be 7 characters");
    }
    
}