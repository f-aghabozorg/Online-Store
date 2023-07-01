using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Orders.Commands.OrderStatusChange
{

    public interface IOrderStatusChangeService
    {
        ResultDto Execute(long OrderId);
    }

    public class OrderStatusChangeService : IOrderStatusChangeService
    {
        private readonly IDataBaseContext _context;


        public OrderStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long OrderId)
        {
            var order = _context.Orders.Find(OrderId);
            if (order == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "سفارش یافت نشد"
                };
            }

            order.OrderState = OrderState.Delivered;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"تغییر وضعیت سفارش به delivered با موفقیت انجام شد!",
            };
        }
    }
}

