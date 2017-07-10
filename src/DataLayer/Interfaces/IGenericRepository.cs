using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseDao<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? page = null,
            int? pageSize = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetById(TKey id, List<Expression<Func<TEntity, object>>> includes = null);

        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        void Add(TEntity entity);

        Task Remove(TKey id);

        void Update(TEntity entityToUpdate);

        void Remove(TEntity entityToDelete);

        Task<int> Count(Expression<Func<TEntity, bool>> condition);
        Task<int> Count(IQueryable<TEntity> query);
        void Commit();
        Task CommitAsync();
    }
}
