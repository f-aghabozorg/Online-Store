using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Store.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Mvc;
using Online_Store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Printing;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(Ordering ordering, string Searchkey, long? CatId = null, int page = 1, int pageSize = 20)
        {
            return View(_productFacad.GetProductForSiteService.Execute(ordering, Searchkey, page, pageSize, CatId).Data);
        }


        public IActionResult Detail(long Id)
        {
            if (_productFacad.GetProductDetailForSiteService.Execute(Id).IsSuccess)
                return View(_productFacad.GetProductDetailForSiteService.Execute(Id).Data);
            else
            {
                return View("NotFound");
            }
            //if (Result_Val)
            //{ return View(Result_Val); }
            //else
            //{
            //    return File("~/404/index.html", "text/html");
            //}
        }
        public IActionResult AdvancedSearch(Ordering ordering,
                                            string Searchkey,
                                            long? CatId = null,
                                            string? Brand = null,
                                            int? MinPrice = null,
                                            int? MaxPrice = null,
                                            int page = 1,
                                            int pageSize = 20)
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "Id", "Name");
            var products = _productFacad.GetProductForSiteService.Execute(ordering, null, page, pageSize, null, null, null, null).Data.Products;
            ViewBag.ProductsMinPrice = products.Min(p => p.Price);
            ViewBag.ProductsMaxPrice = products.Max(p => p.Price);
            //ViewBag.ProductsMidPrice = (ViewBag.ProductsMinPrice + ViewBag.ProductsMaxPrice)/2;

            return View(_productFacad.GetProductForSiteService.Execute(ordering, Searchkey, page, pageSize, CatId, Brand, MinPrice, MaxPrice).Data);
        }
    }
}
