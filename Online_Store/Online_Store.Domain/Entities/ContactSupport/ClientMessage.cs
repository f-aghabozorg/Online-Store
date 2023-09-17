using Online_Store.Domain.Entities.Commons;
using Online_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Domain.Entities.ContactSupport
{
    public class ClientMessage : BaseEntity
    {

        public virtual User User { get; set; }
        public long UserId { get; set; }
         
        public string Topic {  get; set; }
        public string Content { get; set; }
    }
}
