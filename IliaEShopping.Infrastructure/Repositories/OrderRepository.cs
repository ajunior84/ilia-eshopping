using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Data;
using IliaEShopping.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        #region "  Constructors  "

        public OrderRepository(EShoppingDataContext context) : base(context)
        {

        }

        #endregion

        #region "  Public Methods  "


        #endregion
    }
}
