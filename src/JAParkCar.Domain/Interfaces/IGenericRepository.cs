using JAParkCar.Domain.Models;

namespace JAParkCar.Domain.Interfaces;

public interface IGenericRepository<T> where T : BaseModel
{
    Task<(List<T>, int)> GetAllAsync(int skip, int take);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
}