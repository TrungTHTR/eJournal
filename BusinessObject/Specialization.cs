﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Specialization:BaseEntity
    {
        public string SpecializationName { get; set;}
        public Guid MajorId { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<AccountSpecialization> AccountSpecializations { get; set; } = new List<AccountSpecialization>();
    }
}
