using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<Customer> GetWithOdersAsync<Customer>(int id);
    }
}
