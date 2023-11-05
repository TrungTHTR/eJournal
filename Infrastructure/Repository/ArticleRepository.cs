using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;


        public ArticleRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
            _appDbContext = dbContext;
            _claimService = claimService;
            _currentTime = currentTime;
        }

        public async Task<int> CreateArticle(Article article)
        {
            await _appDbContext.Articles.AddAsync(article);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteArticle(Guid id)
        {
            var _article = await GetArticles(id);
            _appDbContext.Articles.Remove(_article);
            return await _appDbContext.SaveChangesAsync();
        }

         //GetAllArticle is Publish
        public async Task<List<Article>> GetAllArticle()
        {
           return await _appDbContext.Articles.Where(x=> x.Status == "Publish").ToListAsync();
        }


        public async Task<Article> GetArticles(Guid id)
        {
            return await _appDbContext.Articles.FindAsync(id);
        }

        public async Task<int> UpdateArticle(Article article)
        {
            var _article = await GetArticles(article.Id);
            if (_article != null)
            {
                _appDbContext.Entry(_article).State = EntityState.Detached;
                _appDbContext.Articles.Update(article);
            }
            return await _appDbContext.SaveChangesAsync();
        }

        //search Article By Title Or AuthorName
        async Task<List<Article>> IArticleRepository.SearchArticle(string value)
        {
            return await _appDbContext.Articles.Where(x => x.Title.Equals(value) || x.AuthorName.Equals(value)).ToListAsync();
        }


    }
}
