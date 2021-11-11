using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region "  Methods  "

        void Add(TEntity entity);
        Task<List<TEntity>> ListAsync();
        Task<TEntity> GetAsync(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> ExistsAsync(int id);

        #endregion
    }
}
