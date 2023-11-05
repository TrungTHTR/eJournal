﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
		public Guid? IssueId { get; set; }
		public int TopicId { get; set; }
		public virtual ICollection<string> Author { get; set; } = new List<string>();
	}
}
