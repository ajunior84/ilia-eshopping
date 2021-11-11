using AutoMapper;
using FluentValidation;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Service.Interfaces;
using IliaEShopping.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Services
{
    /// <summary>
    /// Customer Service
    /// </summary>
    public class CustomerService : BaseService<Customer, CustomerValidator>, ICustomerService
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

            Sanitize(ref customer);

            customer.CreatedAt = DateTime.Now;

            // Validate
            Validator.ValidateAndThrow(customer);

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

            Sanitize(ref customer);

            // Validate
            Validator.ValidateAndThrow(customer);

            UnitOfWork.Customers.Update(customer);
            await UnitOfWork.CommitAsync();
            return customer;
        }

        #endregion

        #region "  ICustomerService Implementation  "

        public Task<Customer> GetWithOdersAsync(int id)
        {
            return UnitOfWork.Customers.GetWithOdersAsync(id);
        }

        public Task<bool> ExistsAsync(int id)
        {
            return UnitOfWork.Customers.ExistsAsync(id);
        }

        #endregion

        #region "  Private Methods  "

        private void Sanitize(ref Customer customer)
        {
            if (customer == null)
            {
                return;
            }

            customer.Name = customer?.Name.Trim().ToUpper();
            customer.Email = customer?.Email.Trim().ToLower();
        }

        #endregion
    }
}
