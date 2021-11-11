using IliaEShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        #region "  Methods  "

        Task<Order> UpdateStatusAsync(int id, short orderStatusId);

        #endregion
    }
}
