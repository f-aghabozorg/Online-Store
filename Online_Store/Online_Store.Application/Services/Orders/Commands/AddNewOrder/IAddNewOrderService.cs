﻿using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Domain.Entities.Finances;

namespace Online_Store.Application.Services.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddNewOrderServiceDto request);
    }

    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDataBaseContext _context;
        public AddNewOrderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddNewOrderServiceDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var cart = _context.Carts.Include(p => p.CartItems)
                       .ThenInclude(p => p.Product)
                       .Where(p => p.Id == request.CartId).FirstOrDefault();

            cart.Finished = true;
            _context.SaveChanges();


            var requestPay = _context.RequestPays.Find(request.requestPayId);
            Order order = new Order()
            {
                Address = request.Address,
                OrderState = OrderState.PayProcessing,
                User = user,
                RequestPay = requestPay,
            };
            _context.Orders.Add(order);

           

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {

                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                };
                orderDetails.Add(orderDetail);
            }
            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "سفارش ایجاد شد.",
            };
        }
    }
    public class RequestAddNewOrderServiceDto
    {
        public long requestPayId { get; set; }
        public long CartId { get; set; }
        public long UserId { get; set; }
        public string Address { get; set; }

    }
}
