using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ArticelRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;
        public ArticelRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
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

        public async Task<int> DeleteArticle(Article article)
        {
            var _article = await _appDbContext.Articles.FindAsync(article);
            _appDbContext.Articles.Remove(_article);
            return await _appDbContext.SaveChangesAsync();
        }

         //GetAllArticle notDelete
        public async Task<List<Article>> GetAllArticle()
        {
           return await _appDbContext.Articles.Where(x=>x.IsDelete.Equals(false)).ToListAsync();
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
    }
}
