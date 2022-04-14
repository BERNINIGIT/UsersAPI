using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UsersAPI.Model.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UsersDbContext _dbContext;

        public GenericRepository(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetSingle(Expression<Func<T, bool>> where)
        {
            IQueryable<T> dbQuery = _dbContext.Set<T>();

            T item = await dbQuery
               .AsNoTracking()
               .SingleOrDefaultAsync(where);

            return item;
        }
        public virtual async Task Update(params T[] items)
        {
            foreach (T item in items)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
