using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Store.Application.Interfaces.FacadPatterns;
using Online_Store.Application.Services.Products.Commands.AddNewProduct;
using Online_Store.Application.Services.Products.Commands.RemoveProduct;
using Online_Store.Application.Services.Products.Commands.EditProduct;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,warehouse_keeper")]

    public class ProductsController : Controller
    {

        private readonly IProductFacad _productFacad;
        private readonly IEditProductService _editProduct;
        private readonly IRemoveProductService _removeProduct;


        public ProductsController(IProductFacad productFacad, IEditProductService editProduct, IRemoveProductService removeProduct)
        {
            _productFacad = productFacad;
            _editProduct = editProduct;
            _removeProduct= removeProduct;
        }
        public IActionResult Index(int Page = 1, int PageSize = 10)
        {
            return View(_productFacad.GetProductForAdminService.Execute(Page, PageSize).Data);
        }

        public IActionResult Detail(long Id)
        {
            
                return View(_productFacad.GetProductDetailForAdminService.Execute(Id).Data);
            
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request, List<AddNewProduct_Features> Features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = Features;
            return Json(_productFacad.AddNewProductService.Execute(request));
        }
        public IActionResult Edit(long Product_Id, int Reduce_Count=0)
        {

           
            return View((_editProduct.Execute(Product_Id, Reduce_Count)));
        }
        public IActionResult Delete(long ProductId)
        {
            return Json(_removeProduct.Execute(ProductId));
        }
    }
}
