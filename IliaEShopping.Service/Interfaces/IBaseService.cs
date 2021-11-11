using FluentValidation;
using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Interfaces
{
    /// <summary>
    /// Base service interface
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region "  Methods  "

        Task<TEntity> AddAsync<TInputModel>(TInputModel inputModel)
            where TInputModel : class;

        Task<int> DeleteAsync(int id);

        Task<List<TEntity>> ListAsync();

        Task<TEntity> GetAsync(int id);

        Task<TEntity> UpdateAsync<TInputModel>(TInputModel inputModel)
            where TInputModel : class;

        #endregion
    }
}
