using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator,warehouse_keeper")]

    public class PayController : Controller
    {
        private readonly IGetRequestPayForAdminService _getRequestPayForAdminService;
        public PayController(IGetRequestPayForAdminService getRequestPayForAdminService)
        {
            _getRequestPayForAdminService = getRequestPayForAdminService;
        }
        public IActionResult Index()
        {
            return View(_getRequestPayForAdminService.Execute().Data);
        }
        public IActionResult ShowRequestPay(long SearchRequestId)
        {
            return View("Index",_getRequestPayForAdminService.Execute(SearchRequestId).Data);
        }
    }
}
