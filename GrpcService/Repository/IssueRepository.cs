using BusinessObject;
using Application.InterfaceService;
using GrpcService.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcService.InterfaceRepository;
namespace GrpcService.Repository
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;
        public IssueRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
            _appDbContext = dbContext;
            _claimService = claimService;
            _currentTime= currentTime;  
        }

        public async Task<List<Issue>> GetAllIssue()
        {
            return await _appDbContext.Issue.Include(x=>x.Articles).ToListAsync();
        }
    }
}
