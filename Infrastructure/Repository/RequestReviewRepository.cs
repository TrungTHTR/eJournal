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
    public class RequestReviewRepository : GenericRepository<RequestReview>, IRequestReviewRepository
    {
        private AppDbContext _dbContext;
        private IClaimService _claimService;
        private ICurrentTime _currentTime;
        public RequestDetailRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
            _dbContext = dbContext;
            _claimService = claimService;
            _currentTime = currentTime;
        }

        public async Task<List<RequestReview>> ShowAllRequestReview(Guid ArticleId)
        {
            return await _dbContext.RequestReviews.Where(x => x.ArticleId.Equals(ArticleId)).ToListAsync();
        }
    }
}
