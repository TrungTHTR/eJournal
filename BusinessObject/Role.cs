using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Rolename { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
