using JAParkCar.Domain.Interfaces;
using JAParkCar.Domain.Models;
using JAParkCar.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.Infra.Database.Repositories;

public class CarRepository(AppDbContext context) : GenericRepository<Car>(context), ICarRepository
{
    public Task<Car?> GetCarPlateAsync(string plate)
    {
        var carOnDb = _context.Cars.FirstOrDefaultAsync(c => c.CarPlate == plate && c.IsActive);
        return carOnDb;
    }
}