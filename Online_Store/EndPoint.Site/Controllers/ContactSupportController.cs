using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Services.Carts;
using Online_Store.Application.Services.ContactSupport.Commands.AddClientMessage;
using Online_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Online_Store.Application.Services.Fainances.Commands.EditAuthorityRequestPayService;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Online_Store.Application.Services.Orders.Commands.AddNewOrder;
using Online_Store.Application.Services.Orders.Queries.GetUserOrders;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class ContactSupportController : Controller
    {
        //private readonly IAddClientMessage _addNewClientMessageService;
        //public ContactSupportController(IAddClientMessage addNewClientMessage)
        //{
        //    _addNewClientMessageService = addNewClientMessage;
        //}
        public IActionResult Index()
        {
            //long UserId = ClaimUtility.GetUserId(User).Value;
            //_addNewClientMessageService.Execute(new RequestAddNewClientMessageServiceDto
            //{
            //    UserId = UserId,
            //    Topic = "",
            //    Content = ""
            //});
            return View();
        }
    }
}
