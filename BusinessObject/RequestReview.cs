using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RequestReview:BaseEntity
    {
        public string RequestTitle { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? ArticleId { get; set; }
        public Article Article { get; set; }
        public ICollection<RequestDetail> Details { get; set; }
    }
}
