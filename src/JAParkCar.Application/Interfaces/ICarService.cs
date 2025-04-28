using JAParkCar.Application.DTO.Car;

namespace JAParkCar.Application.Interfaces;

public interface ICarService
{
    Task RegisterCar(CarCreateDto carDto);
    Task UpdateCar(CarUpdateDto carDto);
    Task DeleteCarAsync(Guid id);
    Task<List<CarGetDto>> GetCarsAsync();
    Task<CarGetDto> GetCarAsync(Guid id);
}