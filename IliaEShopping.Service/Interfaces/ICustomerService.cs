using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        #region "  Methods  "

        Task<Customer> GetWithOdersAsync(int id);

        #endregion
    }
}
