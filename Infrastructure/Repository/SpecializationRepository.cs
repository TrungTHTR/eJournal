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
    public class SpecializationRepository : GenericRepository<Specialization>,ISpecializationRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;
        public SpecializationRepository(AppDbContext dbContext, IClaimService claimService, ICurrentTime currentTime) : base(dbContext, claimService, currentTime)
        {
            _appDbContext = dbContext;
            _claimService = claimService;
            _currentTime = currentTime;
        }

        public  List<string> GetAllSpecializationsNameAsync()
        {
            return  GetAllAsync().Result.Select(x=>x.SpecializationName).ToList();
        }
    }
}
