using JAParkCar.Domain.Interfaces;
using JAParkCar.Domain.Models;
using JAParkCar.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.Infra.Database.Repositories;

public class CarRepository(AppDbContext context) : ICarRepository
{
    private readonly AppDbContext _context = context;
    public async Task AddCarAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCarAsync(Car car)
    {
        var carOnDb = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id && c.Active);
        if (carOnDb is null)
            throw new Exception("Car not found");

        carOnDb.Brand = car.Brand;
        carOnDb.Model = car.Model;
        carOnDb.Color = car.Color;
        carOnDb.CarPlate = car.CarPlate;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(Guid id)
    {
        var carOnDb = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id && c.Active);
        if (carOnDb is null)
            throw new Exception("Car not found");
        
        carOnDb.Active = false;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Car>> GetCarsAsync()
    {
       var cars = await _context.Cars.Where(c => c.Active).ToListAsync();
       return cars;
    }
    public Task<Car?> GetCarAsync(Guid carId)
    {
        var car = _context.Cars.FirstOrDefaultAsync(c => c.Id == carId && c.Active);
        return car;
    }

    public Task<Car?> GetCarPlateAsync(string plate)
    {
        var carOnDb = _context.Cars.FirstOrDefaultAsync(c => c.CarPlate == plate && c.Active);
        return carOnDb;
    }
}