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
    public class RequestReviewRepository : GenericRepository<RequestReview>, IRequestReviewRepository
    {
        private AppDbContext _dbContext;
        private IClaimService _claimService;
        private ICurrentTime _currentTime;
        public RequestReviewRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
            _dbContext = dbContext;
            _claimService = claimService;
            _currentTime = currentTime;
        }

        public async Task<List<RequestReview>> ShowAllRequestReview(Guid ArticleId)
        {
            return await _dbContext.RequestReviews.Where(x => x.ArticleId.Equals(ArticleId)).ToListAsync();
        }
        public async Task<int> CreateRequestReview(RequestReview requestReview)
        {
            await _dbContext.RequestReviews.AddAsync(requestReview);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<RequestReview> GetRequestReviews(Guid id)
        {
            return await _dbContext.RequestReviews.FindAsync(id);
        }
        public async Task<int> UpdateRequestReview(RequestReview requestReview)
        {
            var _requestReview = await GetRequestReviews(requestReview.Id);
            if (_requestReview != null)
            {
                _dbContext.Entry(_requestReview).State = EntityState.Detached;
                _dbContext.RequestReviews.Update(requestReview);
            }
            return await _dbContext.SaveChangesAsync();
        }
    }
}