using JAParkCar.Domain.Models;

namespace JAParkCar.Domain.Interfaces;

public interface ICarRepository
{
    Task AddCarAsync(Car car);
    Task UpdateCarAsync(Car car);
    Task DeleteCarAsync(Guid id);
    Task<List<Car>> GetCarsAsync();
    Task<Car?> GetCarAsync(Guid carId);
    Task<Car?> GetCarPlateAsync(string plate);
}
