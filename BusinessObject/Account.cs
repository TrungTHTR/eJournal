using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Account:BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }
        public string Address { get; set; }
        public string Affiliation { get; set; }
        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }
      
        public virtual Role? Role { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<AccountSpecialization> Specializations { get; set; }
    }
}
