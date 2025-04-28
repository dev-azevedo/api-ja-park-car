using JAParkCar.Domain.Models;

namespace JAParkCar.Domain.Interfaces;
public interface ICarSpaceRepository
{
    Task<CarSpace> GetNumberSpaceAsync(int numberSpace);
    Task<List<CarSpace>> GetCarSpacesAsync();
    Task UpdateCarAsync(CarSpace carSpace);
}