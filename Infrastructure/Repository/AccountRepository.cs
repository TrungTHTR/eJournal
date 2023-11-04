using Application.InterfaceRepository;
using Application.InterfaceService;
using Application.ViewModels.UserViewModels;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
        }

        public async Task<List<UserViewAllModel>> GetAllWithViewModel()
        {
            return await _context.Accounts.Include(x=>x.Role)
                                           .Include(x=>x.Country)
                                           .Select(x=>new UserViewAllModel
                                           {
                                               Id = x.Id,
                                               Address = x.Address,
                                               UserName= x.UserName,
                                               PhoneNumber=x.PhoneNumber,
                                               Affiliation= x.Affiliation,
                                               Email = x.Email,
                                               PasswordHash= x.PasswordHash,
                                               PasswordSalt= x.PasswordSalt,
                                               CountryName=x.Country.CountryName,
                                               RoleName=x.Role.Rolename
                                           }).ToListAsync();
        }
    }
}
