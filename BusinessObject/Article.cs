using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid? IssueId { get; set; }
        public int TopicId { get; set; }
        [ForeignKey(nameof(IssueId))]
        public virtual Issue? Issue { get; set; }
        [ForeignKey(nameof(TopicId))]
        public virtual Topic? Topic { get; set; }
        public virtual ICollection<Author> Author { get; set; } = new List<Author>();
    }
}
