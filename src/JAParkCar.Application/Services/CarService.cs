using AutoMapper;

using JAParkCar.Application.DTO.Car;
using JAParkCar.Application.Interfaces;
using JAParkCar.Domain.Interfaces;
using JAParkCar.Domain.Models;

namespace JAParkCar.Application.Services;

public class CarService(ICarRepository carRepository, IMapper mapper) : ICarService
{
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(CarCreateDto carDto)
    {
        var carOnDb = await _carRepository.GetCarPlateAsync(carDto.CarPlate);
        if(carOnDb is not null)
            throw new Exception("Car already registered");
        
        var car = _mapper.Map<Car>(carDto);
        await _carRepository.CreateAsync(car);
    }

    public async Task UpdateAsync(CarUpdateDto carDto)
    {
        var carOnDb = await _carRepository.GetByIdAsync(carDto.Id);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        carOnDb.Brand = carDto.Brand;
        carOnDb.Model = carDto.Model;
        carOnDb.Color = carDto.Color;
        carOnDb.CarPlate = carDto.CarPlate;
        carOnDb.UpdatedAt = DateTime.Now;
        
        await _carRepository.UpdateAsync(carOnDb);
    }

    public async Task<List<CarGetDto>> GetAllAsync(int skip, int take)
    {
        var (items, totalItem) = await _carRepository.GetAllAsync(skip, take);
        return _mapper.Map<List<CarGetDto>>(items);
    }

    public async Task<CarGetDto> GetByIdAsync(Guid id)
    {
        var carOnDb = await _carRepository.GetByIdAsync(id);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        return _mapper.Map<CarGetDto>(carOnDb);
    }
    
    public async Task<CarGetDto> GetByCarPlateAsync(string carPlate)
    {
        var carOnDb = await _carRepository.GetCarPlateAsync(carPlate);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        return _mapper.Map<CarGetDto>(carOnDb);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var carOnDb = await _carRepository.GetByIdAsync(id);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        carOnDb.IsActive = false;
        carOnDb.UpdatedAt = DateTime.Now;
        
        await _carRepository.UpdateAsync(carOnDb);
    }
}