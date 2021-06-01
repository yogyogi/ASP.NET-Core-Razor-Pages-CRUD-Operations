using Microsoft.EntityFrameworkCore;
using MovieCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieCrud.Entity
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MovieContext context;

        public Repository(MovieContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> ReadAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ReadAllAsync(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
        {
            var all = context.Set<T>();
            var relevant = await all.Skip(skip).Take(take).ToListAsync();
            var total = all.Count();

            (List<T>, int) result = (relevant, total);

            return result;
        }

        public async Task<T> ReadAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
