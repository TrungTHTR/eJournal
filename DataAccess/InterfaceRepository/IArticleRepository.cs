using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
    public interface IArticleRepository: IGenericRepository<Article>
    {

        Task<List<Article>> GetAllArticle();
        Task<Article> GetArticles(Guid id);
        Task<int> CreateArticle(Article article);
        Task<int> UpdateArticle(Article article);
        Task<int> DeleteArticle(Guid id);
        //search Article By Title Or AuthorName
        Task<List<Article>> SearchArticle(string value);
    }
}
