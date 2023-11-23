using System.Linq.Expressions; // 2611
using Domain.Entities;

namespace Domain.Interfaces;

public interface IGenericRepositoryString<T> where T : BaseEntityString
{
    Task<T> GetByIdAsync(string Id);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}