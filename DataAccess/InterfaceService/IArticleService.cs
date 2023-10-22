using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IArticleService
    {
        Task<List<Article>> GetAllArticle();
        Task<Article> GetArticles(Guid id);
        Task<int> CreateArticle(Article article);
        Task<int> UpdateArticle(Article article);
        Task<int> DeleteArticle(Article article);
    }
}
