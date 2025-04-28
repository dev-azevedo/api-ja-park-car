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

    public async Task RegisterCar(CarCreateDto carDto)
    {
        var carOnDb = await _carRepository.GetCarPlateAsync(carDto.CarPlate);
        if(carOnDb is not null)
            throw new Exception("Car already registered");
        
        var car = _mapper.Map<Car>(carDto);
        await _carRepository.AddCarAsync(car);
    }

    public async Task UpdateCar(CarUpdateDto carDto)
    {
        var carOnDb = await _carRepository.GetCarAsync(carDto.Id);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        var car = _mapper.Map<Car>(carDto);
        await _carRepository.UpdateCarAsync(car);
    }

    public async Task DeleteCarAsync(Guid id)
    {
        var carOnDb = await _carRepository.GetCarAsync(id);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        await _carRepository.DeleteCarAsync(id);
    }

    public async Task<List<CarGetDto>> GetCarsAsync()
    {
        var carsOnDb = await _carRepository.GetCarsAsync();
        return _mapper.Map<List<CarGetDto>>(carsOnDb);
    }

    public async Task<CarGetDto> GetCarAsync(Guid id)
    {
        var carOnDb = await _carRepository.GetCarAsync(id);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        return _mapper.Map<CarGetDto>(carOnDb);
    }
}