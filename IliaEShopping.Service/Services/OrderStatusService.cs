using AutoMapper;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Domain.ObjectValues;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Service.Interfaces;
using IliaEShopping.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Services
{
    /// <summary>
    /// Order Status Service
    /// </summary>
    public class OrderStatusService : BaseService<OrderStatus, OrderStatusValidator>, IOrderStatusService
    {
        #region "  Constructors  "

        public OrderStatusService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        #endregion

        #region "  Base Service Implementation  "

        public override Task<OrderStatus> AddAsync<TInputModel>(TInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<OrderStatus> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<OrderStatus>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<OrderStatus> UpdateAsync<TInputModel>(TInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public async Task EnsureCreated()
        {
            var values = Enum.GetValues(typeof(OrderStatusType));

            foreach (var item in values)
            {
                var id = Convert.ToInt16(item);
                var exists = await UnitOfWork.OrderStatuses.ExistsAsync(id);

                if (!exists)
                {
                    var e = (OrderStatusType)id;
                    var name = Enum.GetName(typeof(OrderStatusType), e);

                    UnitOfWork.OrderStatuses.Add(new OrderStatus
                    {
                        Id = id,
                        Name = name
                    });
                }
            }

            await UnitOfWork.CommitAsync();
        }

        #endregion
    }
}
