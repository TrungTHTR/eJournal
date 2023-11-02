﻿using System;
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
        public Guid ArticleId { get; set; }
        public virtual Article? Article { get; set; }
        public virtual ICollection<RequestDetail> Details { get; set; } = new List<RequestDetail>();
    }
}
