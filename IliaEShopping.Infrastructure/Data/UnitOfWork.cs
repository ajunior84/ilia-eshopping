using IliaEShopping.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Data
{
    /// <summary>
    /// Unit of Work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region "  Variables  "

        private readonly EShoppingDataContext _context;

        #endregion

        #region "  Constructors  "

        public UnitOfWork(
            EShoppingDataContext context,
            ICustomerRepository customerRepository,
            IOrderStatusRepository orderStatusRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            Customers = customerRepository;
            OrderStatuses = orderStatusRepository;
            Orders = orderRepository;
        }

        #endregion

        #region "  Repositories  "

        /// <summary>
        /// Customer repository
        /// </summary>
        public ICustomerRepository Customers { get; private set; }

        /// <summary>
        /// Order repository
        /// </summary>
        public IOrderRepository Orders { get; private set; }

        /// <summary>
        /// Order Status repository
        /// </summary>
        public IOrderStatusRepository OrderStatuses { get; private set; }

        #endregion

        #region "  Public Methods  "

        /// <summary>
        /// Commit actions async
        /// </summary>
        /// <returns>Returns the number of affected records</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Commit actions
        /// </summary>
        /// <returns>Returns the number of affected records</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Commit()
        {
            return _context.SaveChanges();
        }

        #endregion
    }
}
