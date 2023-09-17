using Online_Store.Domain.Entities.Commons;
using Online_Store.Domain.Entities.ContactSupport;
using Online_Store.Domain.Entities.Orders;

namespace Online_Store.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public bool IsActive { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // '1' user has 'n' roles
        public ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ClientMessage> ClientMessages { get; set; }
    }
}
