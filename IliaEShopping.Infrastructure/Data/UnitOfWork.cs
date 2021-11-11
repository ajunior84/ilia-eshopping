using IliaEShopping.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure
{
    /// <summary>
    /// Unit of Work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region "  Constructors  "

        public UnitOfWork(
            ICustomerRepository _customerRepository)
        {
            Customers = _customerRepository;
        }

        #endregion

        #region "  Repositories  "

        /// <summary>
        /// Customer Repository
        /// </summary>
        public ICustomerRepository Customers { get; private set; }

        #endregion

        #region "  Public Methods  "

        /// <summary>
        /// Commit actions async
        /// </summary>
        /// <returns>Returns the number of affected records</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Commit actions
        /// </summary>
        /// <returns>Returns the number of affected records</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Commit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
