using JAParkCar.Domain.Models;

namespace JAParkCar.Domain.Interfaces;

public interface ICarRepository : IGenericRepository<Car>
{
    Task<Car?> GetCarPlateAsync(string plate);
}
