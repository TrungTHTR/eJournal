using Application.ViewModels.ArticleViewModels;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleResponse>> GetAll(ArticleStatus? status);
        Task<string> AddArticleFile(IFormFile file);
        Task DownloadArticleFile(Guid id);
    }
}
