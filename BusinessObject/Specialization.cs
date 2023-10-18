using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Specialization:BaseEntity
    {
        public string SpecializationName { get; set;}
        public Guid? MajorId { get; set; }
        public Major Major { get; set; }
        public ICollection<AccountSpecialization> AccountSpecializations { get; set; }
    }
}
