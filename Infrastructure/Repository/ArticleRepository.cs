using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {

        }

        public Task<int> CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteArticle(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticle()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticles(Guid id)
        {
            throw new NotImplementedException();
        }
        //search Article By Title Or AuthorName
        public Task<List<Article>> SearchArticle(string value)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
