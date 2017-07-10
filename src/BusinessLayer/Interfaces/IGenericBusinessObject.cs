using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IGenericBusinessObject<TEntity, TKey>
    {
        Task Add(TEntity Entity);
        Task Update(TEntity Entity);
        Task Remove(TEntity Entity);
        Task<TEntity> GetSingle(TKey Key);
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includes);
        Task<int> Count(Expression<Func<TEntity, bool>> condition);
    }
}
