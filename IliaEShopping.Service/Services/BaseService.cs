using AutoMapper;
using FluentValidation;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Services
{
    public abstract class BaseService<TEntity, TValidator> : IBaseService<TEntity> 
        where TEntity : BaseEntity
        where TValidator : AbstractValidator<TEntity>
    {
        #region "  Variables  "

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly AbstractValidator<TEntity> Validator;

        #endregion

        #region "  Constructors  "

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            UnitOfWork = uow;
            Mapper = mapper;
            Validator = Activator.CreateInstance<TValidator>();
        }

        #endregion

        #region "  Public Methods  "

        public abstract Task<TEntity> AddAsync<TInputModel>(TInputModel inputModel) where TInputModel : class;

        public abstract Task<int> DeleteAsync(int id);

        public abstract Task<TEntity> GetAsync(int id);

        public abstract Task<List<TEntity>> ListAsync();

        public abstract Task<TEntity> UpdateAsync<TInputModel>(TInputModel inputModel) where TInputModel : class;

        #endregion
    }
}
