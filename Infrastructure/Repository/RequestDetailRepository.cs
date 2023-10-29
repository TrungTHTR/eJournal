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
    public class RequestDetailRepository : GenericRepository<RequestDetail>, IRequestDetailRepository
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

        public async Task<List<RequestDetail>> ShowAllRequestDetail(Guid AccountId)
        {
            return await _dbContext.RequestDetails.Where(x => x.AccountId.Equals(AccountId)).ToListAsync();
        }
        public async Task<List<RequestDetail>> GetAllRequestDetail()
        {
            return await _dbContext.RequestDetails.ToListAsync();
        }
    }
}
