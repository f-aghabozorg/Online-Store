using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Fainances.Queries.GetRequestPayForAdmin
{
    public interface IGetRequestPayForAdminService
    {
        ResultDto<List<RequestPayDto>> Execute(long SearchRequestId = -1);
    }

    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RequestPayDto>> Execute(long SearchRequestId = -1)
        {
            List<RequestPayDto> requestPay = new List<RequestPayDto>();
            if (SearchRequestId != -1)
            {
                var temp = _context.RequestPays
                .Include(p => p.User)
                .ToList()
                .Where(p => p.Id == SearchRequestId).FirstOrDefault();
                if (temp != null)
                    requestPay.Add(new RequestPayDto
                    {
                        Id = temp.Id,
                        Amount = temp.Amount,
                        Authority = temp.Authority,
                        Guid = temp.Guid,
                        IsPay = temp.IsPay,
                        PayDate = temp.PayDate,
                        RefId = temp.RefId,
                        UserId = temp.UserId,
                        UserFirstName = temp.User.FirstName,
                        UserLastName = temp.User.LastName
                    });
            }
            else
            {
                requestPay = _context.RequestPays
                .Include(p => p.User)
                .ToList()
                 .Select(p => new RequestPayDto
                 {
                     Id = p.Id,
                     Amount = p.Amount,
                     Authority = p.Authority,
                     Guid = p.Guid,
                     IsPay = p.IsPay,
                     PayDate = p.PayDate,
                     RefId = p.RefId,
                     UserId = p.UserId,
                     UserFirstName = p.User.FirstName,
                     UserLastName = p.User.LastName

                 }).ToList();
            }


            return new ResultDto<List<RequestPayDto>>()
            {
                Data = requestPay,
                IsSuccess = true,
            };
        }
    }
    public class RequestPayDto
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
