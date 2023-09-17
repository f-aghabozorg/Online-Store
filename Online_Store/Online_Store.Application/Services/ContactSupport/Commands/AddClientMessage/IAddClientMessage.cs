using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common.Dto;
using Online_Store.Domain.Entities.ContactSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.ContactSupport.Commands.AddClientMessage
{
    public interface IAddClientMessage
    {
        ResultDto Execute(RequestAddNewClientMessageServiceDto request);
    }

    public class AddClientMessage : IAddClientMessage
    {
        private readonly IDataBaseContext _context;
        public AddClientMessage(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddNewClientMessageServiceDto request)
        {
            var user = _context.Users.Find(request.UserId);
            ClientMessage clientmessage = new ClientMessage()
            {
                Topic = request.Topic,
                Content = request.Content ,
                User = user,

            };
            _context.ClientMessages.Add(clientmessage);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "added successfully.",
            };
        }
    }
    public class RequestAddNewClientMessageServiceDto
    {
        public long UserId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

    }
}
