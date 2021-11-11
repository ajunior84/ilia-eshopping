using AutoMapper;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            this.UnitOfWork = uow;
            Mapper = mapper;
        }

        public abstract Task<TEntity> AddAsync<TInputModel>(TInputModel inputModel) where TInputModel : class;

        public abstract Task<int> DeleteAsync(int id);

        public abstract Task<TEntity> GetAsync(int id);

        public abstract Task<List<TEntity>> ListAsync();

        public abstract Task<TEntity> UpdateAsync<TInputModel>(TInputModel inputModel) where TInputModel : class;
    }
}
