using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Major:BaseEntity
    {
        public string MajorName { get; set;}
        public virtual ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
    }
}
