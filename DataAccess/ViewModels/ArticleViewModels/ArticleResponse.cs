using Application.ViewModels.IssueViewModels;
using Application.ViewModels.UserViewModels;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ArticleViewModels
{
    public class ArticleResponse
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string? ArticleFileUrl { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string AuthorName { get; set; }
        public TopicResponse Topic { get; set; }
        public IssueResponse? Issue { get; set; }
        public string? AccountId { get; set; }
        public IEnumerable<AuthorResponse> Author { get; set; }
    }
}
