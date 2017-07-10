using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataLayer.Interfaces;
using DataLayer.Repository;

namespace BusinessLayer
{
    public class GenericBusinessObject<TEntity, TKey> : IGenericBusinessObject<TEntity, TKey>
       where TEntity : BaseDao<TKey>
       where TKey : IEquatable<TKey>
    {
        private readonly IGenericRepository<TEntity, TKey> _repository;

        public GenericBusinessObject(IGenericRepository<TEntity, TKey> Repository)
        {
            if(Repository == null)
                throw new ArgumentNullException();

            _repository = Repository;
        }

        public GenericBusinessObject(DbContext context)
        {
            _repository = new GenericRepository<TEntity, TKey>(context);
        }

        public virtual async Task Add(TEntity Entity)
        {
            _repository.Add(Entity);
            await _repository.CommitAsync();
        }

        public virtual async Task Update(TEntity Entity)
        {
            _repository.Update(Entity);
            await _repository.CommitAsync();
        }

        public virtual async Task Remove(TEntity Entity)
        {
            _repository.Remove(Entity);
            await _repository.CommitAsync();
        }
        
        public virtual async Task<TEntity> GetSingle(TKey Key)
        {
            return await _repository.GetSingle(x => x.Id.Equals(Key));
        }

        public virtual async Task<TEntity> GetSingle(Expression<Func<TEntity,bool>> condition, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _repository.GetSingle(condition, includes: includes);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _repository.Get(condition, includes: includes);
        }

        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> condition)
        {
            return await _repository.Count(condition);
        }
    }
}