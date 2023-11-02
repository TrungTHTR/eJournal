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
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country? Country { get; set; }
        public virtual Author? Author { get; set; }
        public virtual ICollection<AccountSpecialization> Specializations { get; set; } = new List<AccountSpecialization>();
    }
}
