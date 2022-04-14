using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UsersAPI.Model.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetSingle(Expression<Func<T, bool>> where);
        Task Update(params T[] items);
        Task Remove(params T[] items);
    }
}
