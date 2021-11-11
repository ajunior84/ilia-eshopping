using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Interfaces
{
    public interface IOrderStatusService : IBaseService<OrderStatus>
    {
        #region "  Methods  "

        Task EnsureCreated();

        #endregion
    }
}
