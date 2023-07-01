using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Application.Services.Users.Commands.RemoveUser;
using System;
using System.Linq;

namespace Online_Store.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(long ProductId);
    }
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDataBaseContext _context;

        public RemoveProductService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto Execute(long ProductId)
        {

            var product = _context.Products.Find(ProductId);
            if (product == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کالا یافت نشد"
                };
            }
            product.RemoveTime = DateTime.Now;
            product.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کالا با موفقیت حذف شد"
            };
        }
    }
}
