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
    /// <summary>
    /// Customer Service
    /// </summary>
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region "  Constructors  "

        public CustomerService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        #endregion

        #region "  Base Service Implementation  "

        public override async Task<Customer> AddAsync<TInputModel>(TInputModel inputModel)
        {
            var customer = Mapper.Map<Customer>(inputModel);
            UnitOfWork.Customers.Add(customer);
            await UnitOfWork.CommitAsync();
            return customer;
        }

        public override async Task<int> DeleteAsync(int id)
        {
            var customer = await GetAsync(id);
            UnitOfWork.Customers.Delete(customer);
            var count = await UnitOfWork.CommitAsync();
            return count;
        }

        public override Task<Customer> GetAsync(int id)
        {
            return UnitOfWork.Customers.GetAsync(id);
        }

        public override Task<List<Customer>> ListAsync()
        {
            return UnitOfWork.Customers.ListAsync();
        }

        public override async Task<Customer> UpdateAsync<TInputModel>(TInputModel inputModel)
        {
            var customer = Mapper.Map<Customer>(inputModel);
            UnitOfWork.Customers.Update(customer);
            await UnitOfWork.CommitAsync();
            return customer;
        }

        #endregion

        #region "  ICustomerService Implementation  "

        public Task<Customer> GetWithOdersAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
