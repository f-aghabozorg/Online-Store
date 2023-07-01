using Online_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        // '1' role has 'n' users
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
