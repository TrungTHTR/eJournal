using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Account:BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }
        public string Address { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<AccountSpecialization> Specializations { get; set; }
    }
}
