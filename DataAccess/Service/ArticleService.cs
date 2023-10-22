using Application.InterfaceService;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.CreateArticle(article);
        }

        public async Task<int> DeleteArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.DeleteArticle(article);
        }

        public async Task<List<Article>> GetAllArticle()
        {
            return await _unitOfWork.ArticleRepository.GetAllArticle();
        }

        public async Task<Article> GetArticles(Guid id)
        {
            return await _unitOfWork.ArticleRepository.GetArticles(id);
        }

        public async Task<int> UpdateArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.UpdateArticle(article);
        }
    }
}
