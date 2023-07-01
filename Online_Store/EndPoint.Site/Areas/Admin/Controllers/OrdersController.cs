using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Online_Store.Domain.Entities.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Online_Store.Application.Services.Users.Commands.UserSatusChange;
using Online_Store.Application.Services.Orders.Commands.OrderStatusChange;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin,Operator,warehouse_keeper")]

    public class OrdersController : Controller
    {
        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        private readonly IOrderStatusChangeService _orderStatusChangeService;

        public OrdersController(IGetOrdersForAdminService getOrdersForAdminService
                               ,IOrderStatusChangeService orderStatusChangeService)
        {
            _getOrdersForAdminService = getOrdersForAdminService;
            _orderStatusChangeService = orderStatusChangeService;

        }
        public IActionResult Index(OrderState orderState, string reduce_count_success="")
        {
            return View(_getOrdersForAdminService.Execute(orderState).Data);
        }
        public IActionResult OrderStatusChange(long OrderId)
        {
            return Json(_orderStatusChangeService.Execute(OrderId));
        }
        //public IActionResult OrderProcess(long OrderId)
        //{

        //    return View();

        //}
    }
}
