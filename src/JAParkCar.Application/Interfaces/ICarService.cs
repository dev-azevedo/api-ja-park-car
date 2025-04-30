using JAParkCar.Application.DTO.Car;

namespace JAParkCar.Application.Interfaces;

public interface ICarService
{
    Task CreateAsync(CarCreateDto carDto);
    Task UpdateAsync(CarUpdateDto carDto);
    Task DeleteAsync(Guid id);
    Task<List<CarGetDto>> GetAllAsync(int skip, int take);
    Task<CarGetDto> GetByIdAsync(Guid id);
    Task<CarGetDto> GetByCarPlateAsync(string carPlate);
}