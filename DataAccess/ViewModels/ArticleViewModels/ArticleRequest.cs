using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ArticleViewModels
{
    public class ArticleRequest
    {
        public string Title { get; set; }
        public string? ArticleFileUrl { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string AuthorName { get; set; }
    }
}
