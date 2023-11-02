using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RequestDetail:BaseEntity
    {
        public int Status { get; set; }
        public string Description { get; set; }
        public string? Comments { get; set; }    
        public Guid RequestId { get; set; }
        public virtual RequestReview? RequestReview { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
