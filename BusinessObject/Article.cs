using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Article:BaseEntity
    {
        public string Title { get; set; }
        public string? ArticleFileUrl { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string AuthorName { get; set; }
        public Guid? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
