using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Domain.Entities.Users;
using Online_Store.Domain.Entities.Finances;

namespace Online_Store.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IEditOrderService
    {
        ResultDto Execute(RequestEditOrderServiceDto request);
    }

    public class EditOrderService : IEditOrderService
    {
        private readonly IDataBaseContext _context;
        public EditOrderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestEditOrderServiceDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var order = _context.Orders.Where(p=>p.UserId ==user.Id & p.RequestPayId == request.RequestPayId).FirstOrDefault();
            if (order == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "سفارش یافت نشد"
                };
            }

           

            var requestPay = _context.RequestPays.Find(request.RequestPayId);
            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.RefId = request.RefId;
            requestPay.Authority = requestPay.Authority;
            _context.SaveChanges();


            order.OrderState = OrderState.Processing;
            _context.SaveChanges();

            order.RequestPay = requestPay;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش سفارش انجام شد.",
            };
        }
    }
    public class RequestEditOrderServiceDto
    {
        public long UserId { get; set; }
        public long RequestPayId { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;

    }
}
