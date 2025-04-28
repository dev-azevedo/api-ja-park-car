using Domain.Models;

namespace Domain.Interfaces;

public interface ICarRepository
{
    Task AddCarAsync(Car car);
    Task UpdateCarAsync(Car car);
    Task DeleteCarAsync(Car car);
    Task<List<Car>> GetCarsAsync();
    Task<Car?> GetCarAsync(Guid carId);
    Task<Car?> GetCarPlateAsync(string plate);
}
