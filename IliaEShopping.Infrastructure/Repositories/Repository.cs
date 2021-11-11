using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Data;
using IliaEShopping.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure
{
    /// <summary>
    /// Default repository
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region "  Variables  "

        protected readonly EShoppingDataContext Context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region "  Constructors  "

        public Repository(EShoppingDataContext context)
        {
            Context = context;

            if (context != null)
            {
                _dbSet = context.Set<TEntity>();
            }
        }

        #endregion

        #region "  Public Methods  "

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async virtual Task<TEntity> GetAsync(int id)
        {
            object objId = id;
            return await _dbSet.FindAsync(objId);
        }

        public virtual Task<List<TEntity>> ListAsync()
        {
            return _dbSet.ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual Task<bool> ExistsAsync(int id)
        {
            return _dbSet.AnyAsync(p => p.Id == id);
        }

        #endregion
    }
}
