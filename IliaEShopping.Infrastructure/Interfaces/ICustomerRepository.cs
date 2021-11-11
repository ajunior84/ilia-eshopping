using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Interfaces
{
    public interface ICustomerRepository : IRepository<Domain.Entities.Customer>
    {
        #region "  Methods  "

        Task<Customer> GetWithOdersAsync(int id);

        #endregion
    }
}
