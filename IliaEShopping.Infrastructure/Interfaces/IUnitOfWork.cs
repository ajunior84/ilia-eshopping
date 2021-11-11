using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Interfaces
{
    /// <summary>
    /// Unit of Work interface
    /// </summary>
    public interface IUnitOfWork
    {
        #region "  Repositories  "

        /// <summary>
        /// Customer repository
        /// </summary>
        ICustomerRepository Customers { get; }

        /// <summary>
        /// Order repository
        /// </summary>
        IOrderRepository Orders { get; }

        /// <summary>
        /// Order Status repository
        /// </summary>
        IOrderStatusRepository OrderStatuses { get; }

        #endregion

        #region "  Methods  "

        /// <summary>
        /// Commit actions async
        /// </summary>
        /// <returns>Returns the number of affected records</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<int> CommitAsync();

        /// <summary>
        /// Commit actions
        /// </summary>
        /// <returns>Returns the number of affected records</returns>
        /// <exception cref="NotImplementedException"></exception>
        int Commit();

        #endregion
    }
}
