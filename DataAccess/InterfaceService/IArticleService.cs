
using Application.ViewModels.ArticleViewModels;
using BusinessObject.Enums;
using Microsoft.AspNetCore.Http;
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
        Task<IEnumerable<ArticleResponse>> GetAll(ArticleStatus? status);
        Task<IEnumerable<ArticleResponse>> GetArticlesByCurrentLoginUser();
        Task<ArticleResponse> GetArticleByCurrentLoginUser(string articleId);
        Task<string> AddArticleFile(IFormFile file, Guid id);
        Task<List<Article>> GetAllArticle();
        Task<Article> GetArticles(Guid id);
//<<<<<<< HEAD
        Task<int> CreateArticle(ArticleRequest request);
        Task<int> UpdateArticle(Guid id, ArticleRequest request);
//=======
//        Task<int> CreateArticle(ArticleRequest article);
//      /*  Task<int> CreateArticle(ArticleRequest request);*/
//        Task<int> UpdateArticle(Article article);
//>>>>>>> d355c1e6ccd43c8badb2391c4300ef72a4a649fa
        Task<int> DeleteArticle(Guid id);
        //search Article By Title Or AuthorName
        Task<List<Article>> SearchArticle(string value);
        Task SubmitArticle(Guid id);
        Task PublishArticle(Guid articleId, Guid issueId);
    }
}
