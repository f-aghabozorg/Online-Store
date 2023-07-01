using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndPoint.Site.Models;
using Online_Store.Application.Services.Common.Queries.GetSlider;
using EndPoint.Site.Models.ViewModels.HomePages;
using Online_Store.Application.Services.Common.Queries.GetHomePageImages;
using Online_Store.Application.Interfaces.FacadPatterns;
using Online_Store.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetSliderService _getSliderService;
        private readonly IGetHomePageImagesService _homePageImagesService;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger
            , IGetSliderService getSliderService
            , IGetHomePageImagesService homePageImagesService
            , IProductFacad productFacad)
        {
            _logger = logger;
            _getSliderService = getSliderService;
            _homePageImagesService = homePageImagesService;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSliderService.Execute().Data,
                PageImages = _homePageImagesService.Execute().Data,
                Furniture = _productFacad.GetProductForSiteService.Execute(Ordering.MostVisited
                , "", 1, 6, 27).Data.Products,
                Laptop = _productFacad.GetProductForSiteService.Execute(Ordering.MostVisited
                , "", 1, 6, 1).Data.Products,
                Cloth = _productFacad.GetProductForSiteService.Execute(Ordering.MostVisited
                , "", 1, 6, 33).Data.Products,
            };

            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult deliveryProduct()
        {
            return View();
        }
        public IActionResult RejectProduct()
        {
            return View();
        }
    }
}
