using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Data;
using IliaEShopping.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Repositories
{
    /// <summary>
    /// Customer Repository
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        #region "  Constructors  "

        public CustomerRepository(EShoppingDataContext context) : base(context)
        {

        }

        #endregion

        #region "  ICustomerRepository  "

        public Task<Customer> GetWithOdersAsync(int id)
        {
            return Context.Customer
                .Include(p => p.Orders)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        #endregion
    }
}
