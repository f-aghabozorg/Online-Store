using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Fainances.Commands.EditAuthorityRequestPayService
{
    public interface IEditAuthorityRequestPayService
    {
        ResultDto Execute(Guid guid, string authority);
    }

    public class EditAuthorityRequestPayService : IEditAuthorityRequestPayService
    {
        private readonly IDataBaseContext _context;
        public EditAuthorityRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(Guid guid, string authority)
        {
            var requestPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requestPay != null)
            {
                requestPay.Authority = authority;
                _context.SaveChanges();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "Authority Edited."
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
        }
    }
}
