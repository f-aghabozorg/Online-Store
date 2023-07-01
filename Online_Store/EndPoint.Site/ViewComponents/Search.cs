using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Services.Products.Queries.GetParentCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetParentCategoryService _GetParentCategoryService;
        public Search(IGetParentCategoryService GetParentCategoryService)
        {
            _GetParentCategoryService = GetParentCategoryService;
        }


        public IViewComponentResult Invoke()
        {
            return View(viewName: "Search", _GetParentCategoryService.Execute().Data);
        }
    }
}
