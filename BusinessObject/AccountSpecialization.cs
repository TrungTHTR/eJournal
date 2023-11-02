using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class AccountSpecialization:BaseEntity
    {
        public Guid AccountId { get; set; }
        public virtual Account? Account { get; set; }
        public Guid SpecializationId { get; set; }
        public virtual Specialization? Specialization { get; set; }
        public int ConfidentLevel { get; set; }
    }
}
