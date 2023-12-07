using System.Linq.Expressions;

namespace MovieCrud.Entity
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<List<T>> ReadAllAsync();
		Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take);
        Task UpdateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task DeleteAsync(int id);
        Task<List<T>> ReadAllAsync(Expression<Func<T, bool>> filter);
    }
}
