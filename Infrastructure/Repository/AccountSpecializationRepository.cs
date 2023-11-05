using Application.InterfaceRepository;
using Application.InterfaceService;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AccountSpecializationRepository : GenericRepository<AccountSpecialization>, IAccountSpecializationRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;
        public AccountSpecializationRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
            _dbContext = dbContext;
            _currentTime = currentTime;
            _claimService= claimService;
        }

        public async Task<List<Account>> GetAccountThroughSpecialize(string specializeName)
        {
           return await _dbContext.AccountSpecializations.Include(x=>x.Account)
                .Where(x=>x.Specialization.SpecializationName==specializeName)
                .Select(x=>x.Account)
                .AsQueryable()
                .ToListAsync();
        }
    }
}
