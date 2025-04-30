using JAParkCar.Domain.Interfaces;
using JAParkCar.Domain.Models;
using JAParkCar.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.Infra.Database.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T : BaseModel
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> dataset;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        dataset = _context.Set<T>();
    }

    public virtual async Task<(List<T>, int)> GetAllAsync(int skip = 1, int take = 10)
    {
        var totalItems = await dataset.CountAsync();
        var items = await dataset
            .Skip((skip - 1) * take)
            .Take(take)
            .Where(c => c.IsActive)
            .ToListAsync();
        
        return (items, totalItems);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await dataset.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        try
        {
            await dataset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        try
        {
            _context.Entry(entity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception)
        {
            throw;
        }
    }
}