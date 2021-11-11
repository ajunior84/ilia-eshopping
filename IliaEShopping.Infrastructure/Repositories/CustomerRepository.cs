using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public CustomerRepository(DbContext context) : base(context)
        {

        }

        #endregion
    }
}
