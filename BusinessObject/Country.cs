using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
