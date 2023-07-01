using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Application.Services.Products.Commands.AddNewProduct;
using static Online_Store.Application.Services.Products.Commands.EditProduct.EditProductService;

namespace Online_Store.Application.Services.Products.Commands.EditProduct
{
    public interface IEditProductService
    {
        ResultDto<ResultEditProductDto> Execute(long Product_Id, int Reduce_Count);
    }


    public class EditProductService : IEditProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public EditProductService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }


        public ResultDto<ResultEditProductDto> Execute(long Product_Id, int Reduce_Count)
        {

            try
            {
                var product = _context.Products.Find(Product_Id);
                if (product.Inventory >= Reduce_Count)
                {
                    product.Inventory -= Reduce_Count;
                    _context.SaveChanges();
                }
                else
                {
                    return new ResultDto<ResultEditProductDto>
                    {
                        IsSuccess = false,
                        Message = "موجودی انبار کافی نیست",
                    };
                }

                var data = new ResultEditProductDto()
                {
                    Product_Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    Description = product.Description,
                    Price = product.Price,
                    Inventory = product.Inventory,
                    CategoryId = product.CategoryId,
                    Displayed = product.Displayed,
                };

                return new ResultDto<ResultEditProductDto>
                {
                    Data = data,
                    IsSuccess = true,
                    Message = "ارسال از انبار با موفقیت انجام شد",
                };
            }
            catch (Exception ex)
            {

                return new ResultDto<ResultEditProductDto>
                {

                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }

        }


        public class ResultEditProductDto
        {
            public long Product_Id { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Inventory { get; set; }
            public long CategoryId { get; set; }
            public bool Displayed { get; set; }

        }

    }
}
