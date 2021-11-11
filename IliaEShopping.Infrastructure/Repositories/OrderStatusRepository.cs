using IliaEShopping.Domain.Entities;
using IliaEShopping.Domain.ObjectValues;
using IliaEShopping.Infrastructure.Data;
using IliaEShopping.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Infrastructure.Repositories
{
    /// <summary>
    /// Order Status Repository
    /// </summary>
    public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
    {
        #region "  Constructors  "

        public OrderStatusRepository(EShoppingDataContext context) : base(context)
        {

        }

        #endregion

        #region "  IOrderStatusRepository  "

        
        #endregion
    }
}
