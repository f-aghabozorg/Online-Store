using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Online_Store.Application.Services.Carts;
using Online_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Online_Store.Application.Services.Fainances.Commands.EditAuthorityRequestPayService;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayService;
using Online_Store.Application.Services.Orders.Commands.AddNewOrder;
using Online_Store.Application.Services.Orders.Queries.GetUserOrders;
using Online_Store.Domain.Entities.Users;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly IGetRequestPayService _getRequestPayService;
        private readonly IAddNewOrderService _addNewOrderService;
        private readonly IEditOrderService _editOrderService;
        private readonly IEditAuthorityRequestPayService _editAuthorityRequestPayService;
        private readonly IGetUserOrdersService _getUserOrdersService;
        public string address;

        public PayController(IAddRequestPayService addRequestPayService
                            , ICartService cartService
                            , IGetRequestPayService getRequestPayService
                            , IEditOrderService editOrderService
                            , IAddNewOrderService addNewOrderService
                            , IEditAuthorityRequestPayService editAuthorityRequestPayService
                            , IGetUserOrdersService getUserOrdersService)
        {
            _addRequestPayService = addRequestPayService;
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            _getRequestPayService = getRequestPayService;
            _addNewOrderService = addNewOrderService;
            _editOrderService = editOrderService;
            _editAuthorityRequestPayService = editAuthorityRequestPayService;
            _getUserOrdersService = getUserOrdersService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string user_address)
        {
            if (!user_address.IsNullOrEmpty())
            { 
                address = user_address;
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _addRequestPayService.Execute(cart.Data.SumAmount, UserId.Value);
                var order_result_dto = _addNewOrderService.Execute(new RequestAddNewOrderServiceDto
                {
                    requestPayId = requestPay.Data.RequestPayId,
                    CartId = cart.Data.CartId,
                    UserId = UserId.Value,
                    Address = user_address,
                });

                
                // ارسال در گاه پرداخت
                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = $"https://localhost:7048/Pay/Verify?guid={requestPay.Data.guid}",
                    Description = "پرداخت فاکتور شماره:" + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }

        }


        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {

            var requestPay = _getRequestPayService.Execute(guid);

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);

            _editAuthorityRequestPayService.Execute(guid, authority);
            #region
            //var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{10000}\"}}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //VerificationPayResultDto verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);
            #endregion

            long UserId = ClaimUtility.GetUserId(User).Value;

            if (verification.Status == 100)
            {
                _editOrderService.Execute(new RequestEditOrderServiceDto
                {
                    UserId = UserId,
                    RequestPayId = requestPay.Data.Id,
                    Authority = authority,
                });

                //redirect to orders view
                return View("Order", _getUserOrdersService.Execute(UserId).Data);
            }
            else
            {
                return View();
            }
        }
    }


    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}
