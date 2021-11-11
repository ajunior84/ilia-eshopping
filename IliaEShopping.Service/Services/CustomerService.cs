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

        public override Task<Customer> AddAsync<TInputModel>(TInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Customer>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Customer> UpdateAsync<TInputModel>(TInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "  ICustomerService Implementation  "

        public Task<Customer> GetWithOdersAsync<Customer>(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
