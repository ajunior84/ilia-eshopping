using AutoMapper;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.CrossCutting.Exceptions;
using IliaEShopping.Infrastructure.Interfaces;
using IliaEShopping.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IliaEShopping.Service.Services
{
    /// <summary>
    /// Order Service
    /// </summary>
    public class OrderService : BaseService<Order>, IOrderService
    {
        #region "  Variables  "

        private readonly ICustomerService _customerService;

        #endregion

        #region "  Constructors  "

        public OrderService(
            IUnitOfWork uow,
            IMapper mapper,
            ICustomerService customerService) : base(uow, mapper)
        {
            _customerService = customerService;
        }

        #endregion

        #region "  Base Service Implementation  "

        public override async Task<Order> AddAsync<TInputModel>(TInputModel inputModel)
        {
            var order = Mapper.Map<Order>(inputModel);

            var customerExists = await _customerService.ExistsAsync(order.CustomerId);

            if (!customerExists)
            {
                throw new ValidationException(MessagesResource.CUSTOMER_NOT_FOUND, new
                {
                    order.CustomerId
                });
            }

            Sanitize(ref order);

            order.CreatedAt = DateTime.Now;
            order.OrderStatusHistory.Add(new OrderStatusHistory
            {
                CreatedAt = DateTime.Now,
                OrderStatusId = 1
            });

            UnitOfWork.Orders.Add(order);
            await UnitOfWork.CommitAsync();
            return order;
        }

        public override async Task<int> DeleteAsync(int id)
        {
            var order = await GetAsync(id);
            UnitOfWork.Orders.Delete(order);
            var count = await UnitOfWork.CommitAsync();
            return count;
        }

        public override Task<Order> GetAsync(int id)
        {
            return UnitOfWork.Orders.GetAsync(id);
        }

        public override Task<List<Order>> ListAsync()
        {
            return UnitOfWork.Orders.ListAsync();
        }

        public override async Task<Order> UpdateAsync<TInputModel>(TInputModel inputModel)
        {
            var order = Mapper.Map<Order>(inputModel);

            Sanitize(ref order);

            UnitOfWork.Orders.Update(order);
            await UnitOfWork.CommitAsync();
            return order;
        }

        #endregion

        #region "  IOrderService implementations  "

        public async Task<Order> UpdateStatusAsync(int id, short orderStatusId)
        {
            var order = await GetAsync(id);

            if (order == null)
            {
                throw new ValidationException(MessagesResource.ORDER_NOT_FOUND, new
                {
                    id
                });
            }

            order.OrderStatusId = orderStatusId;
            order.OrderStatusHistory.Add(new OrderStatusHistory
            {
                CreatedAt = DateTime.Now,
                OrderStatusId = orderStatusId
            });

            UnitOfWork.Orders.Update(order);
            await UnitOfWork.CommitAsync();

            return await GetAsync(id);
        }

        #endregion

        #region "  Private Methods  "

        private void Sanitize(ref Order order)
        {
            if (order == null)
            {
                return;
            }
        }

        #endregion
    }
}
